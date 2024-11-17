
//load dữ liệu lên form sửa
function loadData(id) {
    $.ajax({
        type: 'POST',
        data: { "id": id },
        url: '/Admin/Product/Index',
        success: function (response) {
            console.log("Response from server:", response);
            $("#masp").val(response.maSP);
            $("#anhsp").attr("src", response.hinhAnh);
            $("#tensanpham").val(response.tenSP);
            $("#gia").val(response.gia);
            $("#danhmuc").val(response.maDM);
            $("#chatlieu").val(response.chatLieu);
            $("#mamau").val(response.maMau.trim());
            $("#displaycolor").css('backgroundColor', response.maMau.trim());
            $("#mota").val(response.moTa);
            $("#huongdan").val(response.huongDan);
            $.each(response.sanPhamChiTiets, function (index) {
                $("#update-" + response.sanPhamChiTiets[index].maKichCo).val(response.sanPhamChiTiets[index].idctsp);
                $("#kichco-" + response.sanPhamChiTiets[index].maKichCo).val(response.sanPhamChiTiets[index].soLuong);
            })
        },
        error: function (xhr) {
            //debugger;  
            console.log(xhr.responseText);
            alert("Error has occurred..");
        }
    });
}

//Ajax thêm sản phẩm
function themSanPham() {
    let sanpham = {};
    let chitiets = [];
    let form = new FormData();
    let formData = $('#add-form').serializeArray({
    });
    $.each(formData, function (index, value) {
        sanpham["" + value.name + ""] = value.value;
    });
    sanpham["MaDM"] = parseInt(sanpham["MaDM"]);
    sanpham["Gia"] = parseFloat(sanpham["Gia"]);
    sanpham["MaKichCo"] = parseInt(sanpham["MaKichCo"]);
    sanpham["SoLuong"] = parseInt(sanpham["SoLuong"]);

    $(".form-2").each(function () {
        const makichco = $(this).find('input[name="MaKichCo"]').val(); // Sửa thành .find()
        const soluong = $(this).find('input[name="SoLuong"]').val();

        // Kiểm tra giá trị hợp lệ
        if (makichco && soluong) {
            chitiets.push({
                MaKichCo: parseInt(makichco, 10), // Chuyển về số nguyên
                SoLuong: parseInt(soluong, 10),  // Chuyển về số nguyên
            });
        }
    })
    let image = $("#imageFile").prop("files")[0];
    form.append("sanpham", JSON.stringify(sanpham));
    form.append("chitiets", JSON.stringify(chitiets));
    form.append("hinhanh", image);
    console.log("SanPham:", sanpham);
    console.log("ChiTiet:", chitiets);
    $.ajax({
        url: '/Admin/Product/Create',
        type: 'POST',
        cache: false,
        processData: false,
        contentType : false,
        enctype: "multipart/form-data",
        data: form,
        async: true,
        success: function (response) {
            $("#add-message").html(response.message);
            if (response.status == true) {
                $("#add-message").addClass("text-warning");
                setTimeout(function () {
                    window.location.replace("/Admin/Product");
                }, 1000)
            } else {
                $("#add-message").addClass("text-danger");
            }
        },
        error: function (xhr) {
            console.error(xhr.responseText);
            alert("An error has occurred. Check the console for details.");
        }

    });
    return false;
}


//Ajax sửa sản phẩm
function suaSanPham() {
    let sanpham = {};
    let chitiets = [];
    let form = new FormData();
    let formData = $('#update-form').serializeArray({
    });
    $.each(formData, function (index, value) {
        sanpham["" + value.name + ""] = value.value;
    });
    sanpham["MaSP"] = parseInt(sanpham["MaSP"]);
    sanpham["MaDM"] = parseInt(sanpham["MaDM"]);
    sanpham["Gia"] = parseFloat(sanpham["Gia"]);
    sanpham["SoLuong"] = parseInt(sanpham["SoLuong"]);

    $(".form-update").each(function () {
        const idctsp = $(this).find('input[name="IDCTSP"]').val(); // Sửa thành .find()
        const soluong = $(this).find('input[name="SoLuong"]').val();

        // Kiểm tra giá trị hợp lệ
        if (idctsp && soluong) {
            chitiets.push({
                IDCTSP: parseInt(idctsp, 10), // Chuyển về số nguyên
                SoLuong: parseInt(soluong, 10),  // Chuyển về số nguyên
            });
        }
    })

    let image = $("#updateImage").prop("files")[0];
    form.append("sanpham", JSON.stringify(sanpham));
    form.append("chitiets", JSON.stringify(chitiets));
    form.append("hinhanh", image);
    console.log("SanPham:", sanpham);
    console.log("ChiTiet:", chitiets);
    $.ajax({
        url: '/Admin/Product/Update',
        type: 'POST',
        cache: false,
        processData: false,
        contentType: false,
        enctype: "multipart/form-data",
        data: form,
        async: true,
        success: function (response) {
            $("#update-message").html(response.message);
            if (response.status == true) {
                $("#update-message").addClass("text-warning");
                setTimeout(function () {
                    window.location.replace("/Admin/Product");
                }, 1000)
            } else {
                $("#update-message").addClass("text-danger");
            }
        },
        error: function (response) {
            console.log(xhr.responseText);
            alert("Error has occurred..");
        }
    });
    return false;
}

function deleteData(id) {
    $("#delete-masp").val(id);
}

function xoaSanPham() {
    let id = $("#delete-masp").val();
    $.ajax({
        type: 'POST',
        data: { "id": id },
        url: '/Admin/Product/Delete',
        success: function (response) {
            if (response.status == true) {
                $(".cancelPopup").click();
                $("#row-" + id).remove();
            }
        },
        error: function (response) {
            console.log(xhr.responseText);
            alert("Error has occurred..");
        }
    });  
}