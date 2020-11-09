#!/bin/bash

# OIDC_CLAIM_aud="8ddb60ac-9426-4509-9f0f-f2255df566a6"
# OIDC_CLAIM_email="KAJE@ucn.dk"
# OIDC_CLAIM_exp="1598885354"
# OIDC_CLAIM_family_name="Jeppesen"
# OIDC_CLAIM_given_name="Karsten"
# OIDC_CLAIM_iat="1598881454"
# OIDC_CLAIM_iss="https://login.microsoftonline.com/d6338997-214a-4f92-ba75-0397f10a84cc/v2.0"
# OIDC_CLAIM_name="Karsten Jeppesen"
# OIDC_CLAIM_nbf="1598881454"
# OIDC_CLAIM_nonce="QGTzr_5oREVIb9ixienXllRfHgcimKjFxe4u2FOTfuM"
# OIDC_CLAIM_picture="https://graph.microsoft.com/v1.0/me/photo/\$value"
# OIDC_CLAIM_rh="0.AAAAl4kz1kohkk-6dQOX8QqEzKxg240mlAlFnw_yJV31ZqZIABY."
# OIDC_CLAIM_sub="URNF5O-hLeVZmWsNP4E3Lme2IObNmcgA095CSkXBUXI"
# OIDC_CLAIM_tid="d6338997-214a-4f92-ba75-0397f10a84cc"
# OIDC_CLAIM_uti="9nSR8U2YCEiDNUchezFvAA"
# OIDC_CLAIM_ver="2.0"


cat << EOF
Content-type: text/html

EOF



initials=$(echo "$OIDC_CLAIM_email" | cut -f 1 -d '@')
#echo "<p>Initials: $initials</p>"
echo "$initials" | grep -q "[0|1|2|3|4|5|6|7|8|9]" && isTeacher=false || isTeacher=true
# $isTeacher && echo "<p>Is a teacher</p>" || echo "<p>Is a student</p>"


environment=$(export | sed -r "a<br>")
inStream=$(cat | sed -r "a<br>")
#echo "$environment"
htmlName=$(echo "$OIDC_CLAIM_name" | uni2ascii -a J -s 2>/dev/null)


# ARG1 is queueID
doSpeakingOrder() {
	if [ "$1" == "-" ]; then
		theSpeaker="Choose a teacher"
		theQueue="Choose a teacher"
	else
		logger -t TEST.CGI "returning queue for $1"
		first=true
		theQueue=""
		while read line; do
			dsoName=$(echo "$line" | ascii2uni -a J 2>/dev/null)
			if $first; then
				first=false
				theSpeaker="$dsoName"
			else
				[ -n "$theQueue" ] && theQueue="$theQueue<br>$dsoName" || theQueue="$dsoName"
			fi
		done < .so.d/$1
	fi
	cat << EOF
					<div id="sospeaker">
						$theSpeaker
					</div>
					<div id="soqueue">
						$theQueue
					</div>
EOF
}

doChooseTeacher() {
	cat << EOF
	&nbsp;&nbsp;&nbsp;&nbsp;
		<select id="selTeacher" name="selteacherlist">
		<option value="-">Choose Teacher</option>
EOF
	for nn in $(ls -1 .so.d/); do
		echo "<option value=\"$nn\">$nn</option>"
	done
	cat << EOF
		</select>
EOF
}



loadRequest=$(echo "$QUERY_STRING" | cut -f 2 -d '=' | cut -f 1 -d ';')
[ -z "$QUERY_STRING" ] && loadRequest="index"
logger -t TEST.CGI "Command: $loadRequest [$QUERY_STRING]"
# Force change Teacher/Student
#isTeacher=false
case $loadRequest in
	index)
		$isTeacher && cat .soav.d/teacher.html | sed -r "s;MYNAME;$htmlName;g"  || cat .soav.d/student.html | sed -r "s;MYNAME;$htmlName;g"
		[ -d .so.d ] || mkdir .so.d
		$isTeacher && [ ! -e .so.d/$initials ] && cat /dev/null > .so.d/$initials
		;;
	qstatus)
		$isTeacher && theQueueID=$initials || theQueueID=$(echo "$QUERY_STRING" | cut -f 3 -d '=' | cut -f 1 -d ';')
		doSpeakingOrder "$theQueueID"
		;;
	queueme)
		$isTeacher && theQueueID=$initials || theQueueID=$(echo "$QUERY_STRING" | cut -f 4 -d '=' | cut -f 1 -d ';')
		theName=$(echo "$QUERY_STRING" | cut -f 3 -d '=' | cut -f 1 -d ';')
		grep -q "$theName" .so.d/$theQueueID || echo "$theName" >> .so.d/$theQueueID
		;;
	queuepop)
		sed -i 1d .so.d/$initials
		;;
	queueclear)
		cat /dev/null > .so.d/$initials
		;;
	queuetest)
		echo "Anders And" > .so.d/$initials
		echo "Bob Brunsviger" >> .so.d/$initials
		echo "Carl Carlsen" >> .so.d/$initials
		echo "Dorte Dut" >> .so.d/$initials
		echo "Erik Eriksen" >> .so.d/$initials
		;;
	btchooseteacher)
		doChooseTeacher
		;;
	*)
		echo "<html><body><p>Unknown: $loadRequest</p></body></html>"
		;;
esac
logger -t TEST.CGI "Command executed"

