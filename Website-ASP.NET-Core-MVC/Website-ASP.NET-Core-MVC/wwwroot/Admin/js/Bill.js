function dateFormat(d) {
    return ((d.getMonth() + 1) + "").padStart(2, "0")
        + "/" + (d.getDate() + "").padStart(2, "0")
        + "/" + d.getFullYear();
}

function huyDonHang(id) {
    swal({
        title: "Cảnh báo",
        text: "Bạn có chắc về việc hủy đơn hàng này!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    type: 'POST',
                    data: { "mahd": id, "stt": 0 },
                    url: '/Admin/Bill/ChangeStatus',
                    success: function (response) {
                        if (response.status == true) {
                            swal({
                                title: "Thành công!",
                                text: "Sửa trạng thái thành công !",
                                type: "success",
                                icon: "success",
                                timer: 1500,
                                button: false
                            });
                        } else {
                            swal({
                                title: "Thất bại!",
                                text: "Sửa trạng thái không thành công",
                                type: "danger",
                                icon: "error",
                                timer: 1500,
                                button: false
                            });
                        }
                        setTimeout(function () {
                            window.location = "/Admin/Bill";
                        }, 1500);
                    },
                    error: function (response) {
                        //debugger;  
                        console.log(xhr.responseText);
                        alert("Error has occurred..");
                    }
                });
            }
        });
}

function doiTrangThai(id) {
    let tt = $("#hd-trangthai-update-" + id).val();
    $.ajax({
        type: 'POST',
        data: { "mahd": id, "stt": tt },
        url: '/Admin/Bill/ChangeStatus',
        success: function (response) {
            if (response.status == true) {
                swal({
                    title: "Thành công!",
                    text: "Sửa trạng thái thành công !",
                    type: "success",
                    icon: "success",
                    timer: 1500,
                    button: false
                });
            } else {
                swal({
                    title: "Thất bại!",
                    text: "Xem chi tiết tại giỏ hàng nhé <3",
                    type: "danger",
                    icon: "error",
                    timer: 1500,
                    button: false
                });
                setTimeout(function () {
                    window.location = "/Admin/Bill";
                }, 1500);
            }

        },
        error: function (response) {
            //debugger;  
            console.log(xhr.responseText);
            alert("Error has occurred..");
        }
    });
}

function loadDuLieuChiTiet(id) {
    $("#hd-body").empty();
    $.ajax({
        type: 'POST',
        data: { "id": id },
        url: '/Admin/Bill/Index',
        success: function (response) {
            console.log("Response from server:", response);

            // Basic bill information remains the same...
            $("#hd-nguoidat").val(response.hoadon.user.fullName);
            $("#hd-nguoinhan").val(response.hoadon.hoTenNguoiNhan);
            $("#hd-trangthai").val(response.hoadon.trangThai == 0 ? "Đã hủy" :
                (response.hoadon.trangThai == 1) ? "Đang chuẩn bị" :
                    (response.hoadon.trangThai == 2) ? "Đang giao" : "Đã thanh toán");
            $("#hd-ngaydat").val(dateFormat(new Date(response.hoadon.ngayDat)));
            $("#hd-sdt").val(response.hoadon.soDienThoaiNhan);
            $("#hd-diachi").val(response.hoadon.diaChiNhan);
            $("#hd-nguoisua").val(response.hoadon.nguoiSua);
            $("#hd-ngaysua").val(dateFormat(new Date(response.hoadon.ngaySua)));
            $("#hd-ghichu").html(response.hoadon.ghiChu);

            let total = 0;
            let cthdItems = response.cthd;
            let spItems = response.sp;

            $.each(cthdItems, function (index, item) {
                // Debug the structure of each item
                console.log("Item details:", item);
                console.log("sanPhamChiTiet:", item.sanPhamChiTiet);

                let giaMua = item.giaMua || 0;
                let soLuongMua = item.soLuongMua || 0;
                let tongTien = giaMua * soLuongMua;

                // Safely access tenKichCo
                //let kichCo = "";
                //if (item.sanPhamChiTiet &&
                //    item.sanPhamChiTiet.$values &&
                //    item.sanPhamChiTiet.$values[0]) {
                //    kichCo = item.sanPhamChiTiet.tenKichCo;
                //}

                $("#hd-body").append(
                    "<tr><td><img src=" + spItems[index].hinhAnh + " /></td>"
                    + "<td>" + spItems[index].tenSP + "</td>"
                    + "<td>" + giaMua.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }) + "</td>"
                    + "<td>" + soLuongMua + "</td>"
                    + "<td>" + item.sanPhamChiTiet.tenKichCo + "</td>"
                    + "<td>" + tongTien.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }) + "</td>"
                    + "</tr>"
                );
                total += tongTien;
            });

            $("#hd-body").append(
                "<tr><td colspan='4'></td><td>Tổng tiền:</td><td>"
                + total.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }) + "</td></tr>"
            );
        },
        error: function (jqXHR) {
            console.log("Error response:", jqXHR.responseText);
            alert("An error occurred.");
        }
    });
}