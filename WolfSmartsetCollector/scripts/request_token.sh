#!/bin/bash
#cmd="curl 'https://www.wolf-smartset.com/portal/connect/token2' -H 'content-type: application/x-www-form-urlencoded; charset=UTF-8' --data 'grant_type=password&username=$1&password=$2&client_id=ro.client&scope=offline_access+openid+api&website_version=29'"
#cmd="curl 'https://www.wolf-smartset.com/idsrv/connect/token' -H 'content-type: application/x-www-form-urlencoded; charset=UTF-8' --data 'grant_type=password&username=$1&password=$2&client_id=smartset.web&scope=offline_access+openid+api&website_version=29'"
cmd="curl 'https://www.wolf-smartset.com/portal/connect/token' -H 'content-type: application/x-www-form-urlencoded; charset=UTF-8' --data 'grant_type=password&username=$1&password=$2&scope=offline_access&WebApiVersion=2&AppVersion=2.1.12'"
eval $cmd "2>/dev/null"