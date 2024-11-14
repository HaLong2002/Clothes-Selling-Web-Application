//Load sản phẩm lên modal
function loadSanPham(id) {
    $.ajax({
        type: 'POST',
        data: { "id": id },
        url: '/Product/Index',
        success: function (response) {
            console.log("Response from server:", response);  // Moved inside success callback

            if (response) {
                $("#modal-a-hinhanh").attr("href", response.hinhAnh);
                $("#modal-hinhanh").attr("src", response.hinhAnh);
                $("#modal-tensp").html(response.tenSP);
                $("#modal-danhmuc").html(response.danhMuc.tenDanhMuc);
                $("#modal-gia").html(response.gia.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }));
                $("#modal-mamau").val(response.maMau ? response.maMau.trim() : '');
                $.each(response.sanPhamChiTiets, function (index) {
                    $("#kichco-soluong-" + response.sanPhamChiTiets[index].maKichCo).val(response.sanPhamChiTiets[index].idctsp);
                })
                if (response.sanPhamChiTiets[0].soLuong == 0) {
                    $("#order-text").html("Hết hàng ! Hãy chọn kích cỡ khác");
                    $("#order-text").attr("disabled", "disabled");
                }
            }
        },
        error: function (xhr, status, error) {
            console.error("Chi tiết các lỗi:", {
                status: status,
                error: error,
                response: xhr.responseText
            });
            alert("Có lỗi xảy ra khi tải thông tin sản phẩm");
        }
    });
}

//Ajax load số lượng theo size
$(document).on("change", "#modal-kichco-soluong", function () {
    let id = $(this).val();
    $.ajax({
        type: 'POST',
        data: { "id": id },
        url: '/Product/Detail',
        success: function (response) {
            if (response.soLuong > 0) {
                $("#order-text").html("Thêm vào giỏ");
                $("#order-text").removeAttr("disabled");
            } else {
                $("#order-text").html("Hết hàng ! Hãy chọn kích cỡ khác");
                $("#order-text").attr("disabled", "disabled");
            }
        },
        error: function (response) {
            //debugger;  
            console.log(xhr.responseText);
            alert("Error has occurred..");
        }
    });
});

//Ajax thêm sp vào giỏ hàng
function themVaoGioHang() {
    let idctsp = $("#modal-kichco-soluong").val();
    let soluong = $("#modal-soluong").val();
    $.ajax({
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({ "idctsp": idctsp, "soluongmua": soluong }),
        url: '/Cart/AddToCart',
        success: function (response) {
            console.log("Cart-Response from server:", response);  // Moved inside success callback

            if (!response.status)
            {
                swal({
                    title: "Thất bại!",
                    text: "Số lượng hàng trong kho không đủ",
                    type: "danger",
                    icon: "warning",
                    timer: 1500,
                    button: false
                });
            } else {
                $("#product-count").html(response.cart.length);
                $(".close").click();
                swal({
                    title: "Thành công!",
                    text: "Xem chi tiết tại giỏ hàng nhé <3",
                    type: "success",
                    icon: "success",
                    timer: 1500,
                    button: false
                });
            }
        },
        error: function (response) {
            //debugger;  
            console.log(xhr.responseText);
            alert("Error has occurred..");
        }
    });
}
//Ajax xóa sp trong giỏ hàng
function xoaGioHang(idctsp) {
    let total = 0;
    swal({
        title: "Bạn có chắc chắn",
        text: "Xóa sản phẩm này khỏi giỏ hàng",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    type: 'POST',
                    data: { "idctsp": idctsp },
                    url: '/Cart/DeleteFromCart',
                    success: function (response) {
                        if (response.length == 0) {
                            window.location = "/Cart/Orders";
                        } else {
                            $("#row-order-" + idctsp).remove();
                            $("#product-count").html(response.length);
                            $.each(response, function (index) {
                                total += response[index].SoLuongMua * response[index].GiaMua;
                            })
                            $("#order-total").html(total.toLocaleString('it-IT', { style: 'currency', currency: 'VND' }));
                        }
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

//Ajax đặt hàng
function datHang() {
    let data = {};
    let formData = $('#add-bill-form').serializeArray({
    });
    $.each(formData, function (index, value) {
        data["" + value.name + ""] = value.value;
    });
    $.ajax({
        url: '/Bill/CreateBill',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(data),
        dataType: 'json',
        success: function (respone) {
            if (respone.status == true) {
                window.location.replace("/Bill/ListBills");
            } else {
                $("#add-message").addClass("text-danger");
                $("#add-message").html(respone.message);
            }
        },
        error: function (respone) {
            console.log(respone);
        }
    });
    return false;
}

//Ajax Hủy đơn hàng
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
                    url: '/Bill/ChangeStatus',
                    success: function (response) {
                        if (response.status == true) {
                            swal({
                                title: "Thành công!",
                                text: "Hủy đơn hàng thành công !",
                                type: "success",
                                icon: "success",
                                timer: 1500,
                                button: false
                            });
                        } else {
                            swal({
                                title: "Thất bại!",
                                text: "Bạn không thể hủy đơn hàng do đơn hàng đã đang giao",
                                type: "danger",
                                icon: "error",
                                timer: 1500,
                                button: false
                            });
                        }
                        setTimeout(function () {
                            window.location = "/Bill/ListBills";
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