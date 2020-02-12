#!/bin/bash
cmd="curl 'https://www.wolf-smartset.com/portal/api/portal/GetGuiDescriptionForGateway?GatewayId=$2&SystemId=$3' -H 'authorization: Bearer $1'"

eval $cmd "2>/dev/null"