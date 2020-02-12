#!/bin/bash
#cmd="curl 'https://www.wolf-smartset.com/portal/api/portal/GetGuiDescriptionForGateway?GatewayId=$2&SystemId=$3' -H 'authorization: Bearer $1'"
parameter=""
parameter+="-H 'authority: www.wolf-smartset.com' -H 'accept: */*' "
parameter+="-H 'authorization: Bearer $1' "
parameter+="-H 'content-type: application/json; charset=UTF-8' "
parameter+="-H 'origin: https://www.wolf-smartset.com' "
parameter+="-H 'sec-fetch-site: same-origin' "
parameter+="-H 'sec-fetch-mode: cors' "
parameter+="-H 'sec-fetch-dest: empty' "
parameter+="--data-binary '{\"BundleId\":$4,\"IsSubBundle\":false,\"ValueIdList\":$5,\"GatewayId\":$2,\"SystemId\":$3,\"LastAccess\":null,\"GuiIdChanged\":true}'"
# {\"BundleId\":$4,\"IsSubBundle\":false,\"ValueIdList\":[$5],\"GatewayId\":$2,\"SystemId\":$3,\"LastAccess\":null,\"GuiIdChanged\":true}
# {"BundleId":2600,"IsSubBundle":false,"ValueIdList":[3494379537,3494379538,3494379540,3494379542,3494379543,3494379544,3494379545,3494379546,3494379547,3494379548,3494379551,3494379552,3494379553,3494379472,3494379473,3494379475,3494379476,3494379477,3494379478,3494377254,3494379479,3494379480,3494379474,3494379536,3494379539,3494379541,3494379549,3494379550],"GatewayId":13657,"SystemId":17269,"LastAccess":null,"GuiIdChanged":true}
cmd="curl 'https://www.wolf-smartset.com/portal/api/portal/GetParameterValues' $parameter"
# echo $cmd
eval $cmd "2>/dev/null"