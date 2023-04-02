const provinces = [{ "name": "An Giang", "latitude": 10.38038576, "longitude": 105.4200146 }, { "name": "Bà Rịa – Vũng tàu", "latitude": 10.35537437, "longitude": 107.0849776 }, { "name": "Bắc Giang", "latitude": 21.26700808, "longitude": 106.2000187 }, { "name": "Bắc Kạn", "latitude": 22.1333333, "longitude": 105.8333333 }, { "name": "Bạc Liêu", "latitude": 9.280375385, "longitude": 105.7199963 }, { "name": "Bắc Ninh", "latitude": 21.1044382266413, "longitude": 106.133133319567 }, { "name": "Bến Tre", "latitude": 10.234998, "longitude": 106.3749966 }, { "name": "Bình Định", "latitude": 13.77997154, "longitude": 109.1800435 }, { "name": "Bình Dương", "latitude": 10.96907408, "longitude": 106.6527455 }, { "name": "Bình Phước", "latitude": 11.65038576, "longitude": 106.6000459 }, { "name": "Bình Thuận", "latitude": 10.933737, "longitude": 108.1000577 }, { "name": "Cà Mau", "latitude": 9.177358418, "longitude": 105.1500052 }, { "name": "Cần Thơ", "latitude": 10.04999249, "longitude": 105.7700191 }, { "name": "Cao Bằng ", "latitude": 22.66399806, "longitude": 106.2680046 }, { "name": "Đà Nẵng", "latitude": 16.06003908, "longitude": 108.2499711 }, { "name": "Đắk Lắk", "latitude": 12.66704205, "longitude": 108.0499833 }, { "name": "Đắk Nông", "latitude": 12.1721584796618, "longitude": 107.726448041207 }, { "name": "Điện Biên", "latitude": 21.74000399, "longitude": 103.3430047 }, { "name": "Đồng Nai", "latitude": 10.9974217865446, "longitude": 107.227351172093 }, { "name": "Đồng Tháp", "latitude": 10.46700013, "longitude": 105.6359976 }, { "name": "Gia Lai", "latitude": 13.98329246, "longitude": 108.0000122 }, { "name": "Hà Giang", "latitude": 22.83365664, "longitude": 104.9833488 }, { "name": "Hà Nam", "latitude": 20.5363153826029, "longitude": 106.018752119982 }, { "name": "Hà Nội", "latitude": 21.0257804571302, "longitude": 105.85498737621 }, { "name": "Hà Tĩnh", "latitude": 18.33377626, "longitude": 105.900037 }, { "name": "Hải Dương", "latitude": 20.94200108, "longitude": 106.3310046 }, { "name": "Hải Phòng", "latitude": 20.8465728687185, "longitude": 106.700805867238 }, { "name": "Hậu Giang", "latitude": 9.7824498392746, "longitude": 105.651914021439 }, { "name": "Hòa Bình", "latitude": 20.81370241, "longitude": 105.3383142 }, { "name": "Hưng Yên", "latitude": 20.805568130022, "longitude": 106.060834847501 }, { "name": "Khánh Hòa", "latitude": 12.25003908, "longitude": 109.1700183 }, { "name": "Kiên Giang", "latitude": 10.01539512, "longitude": 105.0913525 }, { "name": "Kon Tum", "latitude": 14.38375897, "longitude": 107.9833207 }, { "name": "Lai Châu", "latitude": 22.3593532309256, "longitude": 103.254174615286 }, { "name": "Lâm Đồng", "latitude": 11.7539759431769, "longitude": 108.198121747166 }, { "name": "Lạng Sơn", "latitude": 21.8459971, "longitude": 106.7570016 }, { "name": "Lào Cai", "latitude": 22.50135134, "longitude": 103.9659948 }, { "name": "Long An", "latitude": 10.53373557, "longitude": 106.416698 }, { "name": "Nam Định", "latitude": 20.42003135, "longitude": 106.2000187 }, { "name": "Nghệ An", "latitude": 18.6999813, "longitude": 105.6799987 }, { "name": "Ninh Bình", "latitude": 20.25430503, "longitude": 105.9750195 }, { "name": "Ninh Thuận", "latitude": 11.56703168, "longitude": 108.9833113 }, { "name": "Phú Thọ", "latitude": 21.33041506, "longitude": 105.4299882 }, { "name": "Phú Yên", "latitude": 13.08200402, "longitude": 109.3159987 }, { "name": "Quảng Bình", "latitude": 17.48333722, "longitude": 106.6000459 }, { "name": "Quảng Nam", "latitude": 15.6249287646788, "longitude": 108.070276296175 }, { "name": "Quảng Ngãi", "latitude": 15.15043052, "longitude": 108.8299873 }, { "name": "Quảng Ninh", "latitude": 20.9604118, "longitude": 107.1000154 }, { "name": "Quảng Trị", "latitude": 16.8499981, "longitude": 107.1333007 }, { "name": "Sóc Trăng", "latitude": 9.603740661, "longitude": 105.9800321 }, { "name": "Sơn La", "latitude": 21.32800214, "longitude": 103.9100047 }, { "name": "Tây Ninh", "latitude": 11.32299911, "longitude": 106.1469997 }, { "name": "Thái Bình", "latitude": 20.45030412, "longitude": 106.3330296 }, { "name": "Thái Nguyên", "latitude": 21.59995933, "longitude": 105.8300154 }, { "name": "Thanh Hóa", "latitude": 19.8200163, "longitude": 105.7999914 }, { "name": "Thừa Thiên Huế", "latitude": 16.46998822, "longitude": 107.5800378 }, { "name": "Tiền Giang", "latitude": 10.4407591279087, "longitude": 106.202011333818 }, { "name": "Thành phố Hồ Chí Minh", "latitude": 10.78002545, "longitude": 106.6950272 }, { "name": "Trà Vinh", "latitude": 9.934002087, "longitude": 106.3340017 }, { "name": "Tuyên Quang", "latitude": 21.8179981, "longitude": 105.2109996 }, { "name": "Vĩnh Long", "latitude": 10.256004, "longitude": 105.9640026 }, { "name": "Vĩnh Phúc", "latitude": 21.3717248525866, "longitude": 105.570566950141 }, { "name": "Yên Bái", "latitude": 21.70500304, "longitude": 104.8750026 }];
const zoomIn = 13, zoomOut = 10;
let map, markers;
let chargingStations;
let stationsByProvince = [];


$(document).ready(function () {
    let beginLocation = provinces.find(x => x.name == "Hà Nội");
    createMap(beginLocation.latitude, beginLocation.longitude, zoomIn);

    getAllStations(function (output) {
        loadMap(output.data);
        setupTypeahead(output.data);
    });

    loadProvinceSelection();
    provinceSelectionChange();
    
    $('#typeahead').bind('typeahead:select', function (ev, suggestion) {
        map.flyTo([suggestion.latitude, suggestion.longitude], zoomIn);
    });
});

function getAllStations(handleData) {
    $.ajax({
        url: "/chargingStations/GetAllChargingStation",
        type: "GET",
        datatype: "json",
        success: function (data) {
            chargingStations = data.data;
            handleData(data);
        },
        error: function () {
            alert("fail");
        }
    });
}

function createMap(startingLat, startingLng, startingZoom) {
    map = L.map('map').setView([startingLat, startingLng], startingZoom);

    L.tileLayer('https://{s}.tile.osm.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="https://osm.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map); 
}

function loadMap(stations) {  
    markers = L.markerClusterGroup();
    for (let i = 0; i < stations.length; i++) {
        let station = stations[i];
        let stationName = station.name;
        let marker = L.marker(new L.LatLng(station.latitude, station.longitude), {
            title: stationName
        });
        marker.bindPopup(stationName);
        markers.addLayer(marker);
    }
    map.addLayer(markers);
}

function loadProvinceSelection() {
    let selection = $('#province_selection');

    for (let item of provinces) {
        selection.append(`<option value = '${item.name}'>${item.name}</option>`);
    }
}

function provinceSelectionChange() {
    $('#province_selection').on("change", function () {
        let province = this.value;
        let object = provinces.find(x => x.name == province);

        if (province != undefined || province != "") {
            markers.remove();
            if (province == "tỉnh thành") {
                stationsByProvince = chargingStations;
                loadMap(chargingStations);               
                return;
            }

            stationsByProvince = [];
            for (let item of chargingStations) {
                if (item.province == province) {
                    stationsByProvince.push(item);
                }
            }
            
            loadMap(stationsByProvince);
            map.flyTo([object.latitude, object.longitude], zoomOut);
        }
    });
}

function setupTypeahead(data) {
    let stations = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('address'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        local: data
    });

    $('#typeahead').typeahead({
        hint: true,
        highlight: true,
        miniLength: 1
    }, {
        name: 'stations',
        display: 'address',
        source: stations
    });
}