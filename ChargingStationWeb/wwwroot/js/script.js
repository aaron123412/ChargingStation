var map;
var markers;
const provinces = ["An Giang", "Bà Rịa – Vũng tàu", "Bắc Giang", "Bắc Kạn", "Bạc Liêu", "Bắc Ninh", "Bến Tre", "Bình Định", "Bình Dương", "Bình Phước", "Bình Thuận", "Cà Mau", "Cần Thơ", "Cao Bằng ", "Đà Nẵng", "Đắk Lắk", "Đắk Nông", "Điện Biên", "Đồng Nai", "Đồng Tháp", "Gia Lai", "Hà Giang", "Hà Nam", "Hà Nội", "Hà Tĩnh", "Hải Dương", "Hải Phòng", "Hậu Giang", "Hòa Bình", "Hưng Yên", "Khánh Hòa", "Kiên Giang", "Kon Tum", "Lai Châu", "Lâm Đồng", "Lạng Sơn", "Lào Cai", "Long An", "Nam Định", "Nghệ An", "Ninh Bình", "Ninh Thuận", "Phú Thọ", "Phú Yên", "Quảng Bình", "Quảng Nam", "Quảng Ngãi", "Quảng Ninh", "Quảng Trị", "Sóc Trăng", "Sơn La", "Tây Ninh", "Thái Bình", "Thái Nguyên", "Thanh Hóa", "Thừa Thiên Huế", "Tiền Giang", "Thành phố Hồ Chí Minh", "Trà Vinh", "Tuyên Quang", "Vĩnh Long", "Vĩnh Phúc", "Yên Bái"];

$(document).ready(function () {
    createMap(21.02014554822514, 105.784259312448, 13);

    getAllStations(function (output) {
        loadMap(output.data);
    });

    loadProvinceSelection();
    provinceSelectionChange();
});

function getAllStations(handleData) {
    $.ajax({
        url: "/chargingStations/GetAllChargingStation",
        type: "GET",
        datatype: "json",
        success: function (data) {
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
    for (var i = 0; i < stations.length; i++) {
        var station = stations[i];
        var stationName = station.name;
        var marker = L.marker(new L.LatLng(station.latitude, station.longitude), {
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
        selection.append(`<option value = '${item}'>${item}</option>`);
    }
}

function provinceSelectionChange() {
    $('#province_selection').on("change", function () {
        let province = this.value;

        if (province != undefined || province != "") {
            getAllStations(function (output) {
                markers.remove();
                if (province == "tỉnh thành") {                 
                    loadMap(output.data);
                    return;
                }

                var stationsByProvince = [];
                for (var item of output.data) {
                    if (item.province == province) {
                        stationsByProvince.push(item);
                    }
                }

                loadMap(stationsByProvince);
            });
        }
    });

}