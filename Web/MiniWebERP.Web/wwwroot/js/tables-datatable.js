﻿$(function () {
    var e = $("#datatable1").DataTable({
        responsive: { details: !1 }
    });
    $(document).on("sidebarChanged", function () {
        e.columns.adjust(), e.responsive.recalc(), e.responsive.rebuild();
    });
});