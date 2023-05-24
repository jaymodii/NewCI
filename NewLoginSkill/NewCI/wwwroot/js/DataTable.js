$(document).ready(function () {
    $('#searchUser').on('keyup', function () {
        dataTable.search($(this).val()).draw();
    });

    // Remove the existing DataTables initialization code and options
});
