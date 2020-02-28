# Wolf-Smartset-to-openhab
Wolf Smartset Cloud-Connection for openhab

## Download
![.NET Core](https://github.com/BoBiene/Wolf-Smartset-to-openhab/workflows/.NET%20Core/badge.svg)


## Usage 

Replace ```<<USERNAME>>``` and ```<<PASSWORD>>``` with you Log-in credentials from https://www.wolf-smartset.com/ Portal.
The WolfSmarset Collecor will query the Smartset API for you Heating configuration and genreate all needed Item, Rules, script and sitemap files in the specified output-directory.

```
run dotnet .\WolfSmartsetCollector.dll -u "<<USERNAME>>" -p "<<PASSWORD>>"
```

## Requirements
  1. Linux / Bash
  2. JsonTransform (http://docs.openhab.org/addons/transformations/jsonpath/readme.html)
  3. curl accessable via Path (I use http://www.paehl.com/open_source/?CURL_7.55.1)
  4. Recommend: Basic UI
  5. https://www.wolf-smartset.com/ Account and a ISM7i, ISM7e, Wolf Link Pro or Wolf Link Home

## Tested WOLF-Devices

| WOLF Equipment    | openhab Version | Used gateway  |
|-------------------|-----------------|---------------|
| CSZ (CGB and SM1) | 2.5             | WOLF Link Pro |
|                   |                 |               |

Note: Please update this table if you did a successfull test

## Supported Heating-Devices

### Regarding documentation from WOLF
https://www.wolf.eu/fileadmin/Wolf_Daten/Dokumente/FAQ/3065655_201711.pdf

| Heating system                            | WOLF Link home        | WOLF Link pro      |
|-------------------------------------------|-----------------------|--------------------|
| Gas-Brennwertgerät CGB-2, CGW-2, CGS-2    | :heavy_check_mark:    | :heavy_check_mark: |
| Öl-Brennwertgerät TOB                     | :heavy_check_mark:    | :heavy_check_mark: |
| Gas Brennwertkessel MGK-2                 | :heavy_check_mark:    | :heavy_check_mark: |
| Split-Luft/Wasser-Wärmepumpe BWL-1S       | :heavy_check_mark:    | :heavy_check_mark: |
| Öl Brennwertgerät COB                     |                       | :heavy_check_mark: |
| Gas Brennwertkessel MGK                   |                       | :heavy_check_mark: |
| Gas Brennwertgeräte CGB, CGW, CGS, FGB    |                       | :heavy_check_mark: |
| Gas Heizwertgeräte CGG-2, CGU-2           |                       | :heavy_check_mark: |
| Kesselregelungen R2, R3, R21              |                       | :heavy_check_mark: |
| Monoblock-Wärmepumpen BWW-1, BWL-1, BWS-1 |                       | :heavy_check_mark: |
| Mischermodul MM, MM-2                     | :black_square_button: | :heavy_check_mark: |
| Kaskadenmodul KM, KM-2                    | :black_square_button: | :heavy_check_mark: |
| Solarmodule SM1, SM1-2, SM-2, SM2-2       | :black_square_button: | :heavy_check_mark: |
| Comfort-Wohnungs-Lüftung CWL Excellent    | :black_square_button: | :heavy_check_mark: |
| Klimageräte KG Top, CKL Pool*             |                       | :heavy_check_mark: |
| Lüftungsgeräte CKL, CFL, CRL*             |                       | :heavy_check_mark: |
| Blockheizkraftwerke                       |                       | :heavy_check_mark: |

Note: 

:black_square_button: in Verbindung mit einem WOLF Link home kompatiblen Heizgerät möglich,
voller Funktionsumfang nur bei Geräten mit aktuellem Softwarestand.

``` * ```Modbus Schnittstelle im Gerät erforderlich,
Sonderprogrammierungen können nicht abgebildet werden.
