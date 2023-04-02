var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/chargingStations/GetAllChargingStation",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "province", "width": "10%" },
            { "data": "address", "width": "40%" },
            { "data": "totalChargerPorts", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                        return `<div class="text-center">
                                <a href="/ChargingStations/Upsert/${data}" class='btn btn-success text-white'
                                    style='cursor:pointer;'> <i class='bi bi-pencil-square'></i></a>
                                    &nbsp;
                                <a onclick=Delete("/ChargingStations/Delete/${data}") class='btn btn-danger text-white'
                                    style='cursor:pointer;'> <i class='bi bi-trash'></i></a>
                                </div>
                            `;
                }, "width": "20%"
            }
        ]
    });
}

function Delete(url) {
    swal({
        title: "Are you sure you want to Delete?",
        text: "You will not be able to restore the data!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error("Deletion not successful");
                    }
                }
            });
        }
    });
}