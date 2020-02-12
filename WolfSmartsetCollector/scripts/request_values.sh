#!/bin/bash
parameter=""
parameter+="-H 'authority: www.wolf-smartset.com' -H 'accept: */*' "
parameter+="-H 'authorization: Bearer $1' "
parameter+="-H 'content-type: application/json; charset=UTF-8' "
parameter+="-H 'origin: https://www.wolf-smartset.com' "
parameter+="-H 'sec-fetch-site: same-origin' "
parameter+="-H 'sec-fetch-mode: cors' "
parameter+="-H 'sec-fetch-dest: empty' "
parameter+="--data-binary '{\"GatewayId\":$2,\"SystemId\":$3,\"BundleId\":$4,\"ValueIdList\":[$5], \"LastAccess\": null,\"GuiIdChanged\":true}'"
cmd="curl 'https://www.wolf-smartset.com/portal/api/portal/GetParameterValues' $parameter"

eval $cmd "2>/dev/null"