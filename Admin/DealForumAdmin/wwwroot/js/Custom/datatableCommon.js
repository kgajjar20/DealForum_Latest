
//jquery datatable common settings
$.fn.DataTable.ext.pager.numbers_length = 5;

$.extend(true, $.fn.dataTable.defaults, {
    dom:
        "<'row'<'col-sm-6'l><'col-sm-6'f>>" +
        "<'row'<'col-sm-12'tr>>" +
        "<'row'<'col-sm-4'i><'col-sm-4 text-center'><'col-sm-4'p>>",
    "processing": true, // for show progress bar
    "serverSide": true, // for process server side
    "searching": true,
    "ordering": true,
    "orderMulti": false, // for disable multiple column at once
    //"order": [[0, "desc"]], // for default ordering
    "paging": true,
    "lengthMenu": [[10, 50, 100, 500, -1], [10, 50, 100, 500, "All"]],
    "scrollY": "550px",
    "scrollCollapse": true,
    "scrollX": true,
    "autoWidth": true,
    "info": true, // hide "Showing 1 to N of N entries
    "pagingType": "full_numbers",
    "language": {
        "lengthMenu": "Showing _MENU_ records per page",
        "zeroRecords": "No record(s) found.",
        "info": "Showing _START_ to _END_ of _TOTAL_ entries",
        "infoEmpty": "No record(s) found.",
        "infoFiltered": "(filtered from _MAX_ total records)",
        "paginate": {
            "previous": "<i class='fa fa-backward'></i>",
            "next": "<i class='fa fa-forward'></i>",
            "first": "<i class='fa fa-step-backward'></i>",
            "last": "<i class='fa fa-step-forward'></i>"
        }
    },
});
