function formatDateForInput(d) {
    const year = d.getFullYear();
    const month = (d.getMonth() + 1).toString().padStart(2, "0");
    const day = d.getDate().toString().padStart(2, "0");
    return `${year}-${month}-${day}`; // Format to yyyy-mm-dd
}

//load dữ liệu lên form sửa
function loadData(id) {
    $.ajax({
        type: 'POST',
        data: { "id": id },
        url: '/Admin/ClientUser/Index',
        success: function (response) {
            console.log("Response from server: ", response);

            const item = response.model;

            $("#matk").val(item.id);
            $("#email").val(item.email);
            $("#fullName").val(item.fullName);
            $("#phoneNumber").val(item.phoneNumber);
            $("#address").val(item.address);
            if (item.date != null)
                $("#date").val(formatDateForInput(new Date(item.date)));
            else
                $("#date").val(new Date(item.date));
            $("#gender").val(item.gender);
            if (item.existingImage != null)
                $("#imagePreview").attr("src", item.existingImage);
            else
                $("#imagePreview").attr("src", "/Images/CustomerAvatars/default-avatar.png");
            $(`#${item.lockoutStatus ? 'blocked' : 'active'}`).prop("checked", true);
        },
        error: function (jqXHR) {
            console.log("Error response:", jqXHR.responseText);
            alert("An error occurred while loading data.");
        }
    });
}

//Ajax thêm tài khoản
function themTaiKhoan() {
    let formData = $('#add-form').serializeArray();
    let data = {};

    // Convert form data to object with proper null handling
    $.each(formData, function (index, item) {
        // Trim the value
        let value = item.value.trim();

        // Handle optional fields - convert empty strings to null
        switch (item.name) {
            case 'PhoneNumber':
            case 'Address':
            case 'Gender':
                data[item.name] = value === '' ? null : value;
                break;
            case 'Date':
                data[item.name] = value === '' ? null : value;
                break;
            default:
                data[item.name] = value;
        }
    });

    const emailInput = document.getElementById("themEmail");
    const email = emailInput.value.trim();
    const emailPattern = /^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$/i;

    // Required field validations
    if (!email) {
        swal({
            title: "Thất bại!",
            text: "Email không được để trống!",
            icon: "error",
            button: "OK"
        });
        return false;
    }

    if (!emailPattern.test(email)) {
        swal({
            title: "Thất bại!",
            text: "Email không hợp lệ!",
            icon: "error",
            button: "OK"
        });
        return false;
    }

    if (!data.FullName) {
        swal({
            title: "Thất bại!",
            text: "Họ và tên không được để trống!",
            icon: "error",
            button: "OK"
        });
        return false;
    }

    if (!data.Password) {
        swal({
            title: "Thất bại!",
            text: "Mật khẩu không được để trống!",
            icon: "error",
            button: "OK"
        });
        return false;
    }

    if (data.Password !== data.ConfirmPassword) {
        swal({
            title: "Thất bại!",
            text: "Mật khẩu không khớp!",
            icon: "error",
            button: "OK"
        });
        return false;
    }

    // Phone number validation if provided
    if (data.PhoneNumber) {
        const phonePattern = /^\d{10}$/;
        if (!phonePattern.test(data.PhoneNumber)) {
            swal({
                title: "Thất bại!",
                text: "Số điện thoại phải chứa đúng 10 chữ số!",
                icon: "error",
                button: "OK"
            });
            return false;
        }
    }

    console.log("Sending data:", data);

    // AJAX request
    $.ajax({
        url: '/Admin/ClientUser/Create',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(data),
        dataType: 'json',
        success: function (response) {
            console.log("Response received:", response);
            if (response.status) {
                swal({
                    title: "Thêm thành công!",
                    text: response.message,
                    icon: "success",
                    button: "OK",
                }).then(function () {
                    window.location.replace("/Admin/ClientUser");
                });
            } else {
                swal({
                    title: "Thất bại!",
                    text: response.message,
                    icon: "error",
                    button: "OK"
                });
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.error("Error details:", {
                status: jqXHR.status,
                statusText: jqXHR.statusText,
                responseText: jqXHR.responseText
            });

            swal({
                title: "Lỗi!",
                text: "Đã xảy ra lỗi trong quá trình xử lý. Vui lòng thử lại sau.",
                icon: "error",
                button: "OK"
            });
        }
    });

    return false;
}

//ajax sửa tài khoản
function suaTaiKhoan() {
    let form = $('#update-form')[0];
    let formData = new FormData(form);

    const lockoutStatus = $("input[name='LockoutStatus']:checked").val() === 'true';  // Convert to boolean (true or false)
    formData.append('LockoutStatus', lockoutStatus);

    $.ajax({
        url: '/Admin/ClientUser/Update',
        type: 'POST',
        data: formData,
        contentType: false, // Important for file upload
        processData: false, // Important for file upload
        success: function (response) {
            if (response.status) {
                swal({
                    title: "Thành công!",
                    text: response.message,
                    icon: "success",
                    timer: 1500,
                    button: false
                });
                setTimeout(function () {
                    window.location.replace("/Admin/ClientUser");
                }, 1500);
            } else {
                swal({
                    title: "Thất bại!",
                    text: response.message,
                    icon: "error",
                    button: "OK"
                });
                //$("#update-message").html(response.message).addClass("text-danger").removeClass("text-success");
            }
        },
        error: function (response) {
            console.error(response);
        }
    });
    return false;
}

function doiEmail() {
    const userId = document.getElementById("matk").value;
    const emailInput = document.getElementById("email"); // Get the input element
    const email = emailInput.value; // Get the input value
    const emailPattern = /^[a-z0-9._%+-]+@gmail\.com$/i;

    if (!emailPattern.test(email)) {
        //alert("Email không hợp lệ!");
        swal({
            title: "Thất bại!",
            text: "Email không hợp lệ!",
            icon: "error",
            button: "OK",
        });
        emailInput.focus(); // Focus on the input element
        return;
    }

    $.ajax({
        url: '/Admin/ClientUser/ChangeEmail',
        type: 'GET',
        data: { id: userId, email: email }, // Send `id` and `email` as query parameters
        success: function (response) {
            if (response.status) {
                swal({
                    title: "Thành công!",
                    text: response.message,
                    icon: "success",
                    button: "OK",
                }).then(function () {
                    window.location.replace("/Admin/ClientUser");
                });
            }
            else {
                swal({
                    title: "Thất bại!",
                    text: response.message,
                    icon: "error",
                    button: "OK",
                })
            }
        },
        error: function (response) {
            swal({
                title: "Lỗi!",
                text: "Có lỗi khi gửi yêu cầu. Vui lòng thử lại.",
                icon: "error",
                button: "OK",
            });
            console.error(response);
        }
    });
}

function guiEmailXacNhan(id) {
    $.ajax({
        url: '/Admin/ClientUser/SendEmailConfirmation',
        type: 'GET',
        data: { "id": id },
        success: function (response) {
            if (response.status) {
                swal({
                    title: "Thành công!",
                    text: response.message,
                    icon: "success",
                    button: "OK",
                }).then(function () {
                    window.location.replace("/Admin/ClientUser");
                });
            }
            else {
                swal({
                    title: "Thất bại!",
                    text: response.message,
                    icon: "error",
                    button: "OK",
                })
            }
        },
        error: function (response) {
            swal({
                title: "Lỗi!",
                text: "Có lỗi khi gửi yêu cầu. Vui lòng thử lại.",
                icon: "error",
                button: "OK",
            });
            console.error(response);
        }
    });
}

//load data lên form xóa
function deleteData(id) {
    $("#delete-user-matk").val(id);
}

function xoaTaiKhoan() {
    let id = $("#delete-user-matk").val();
    $.ajax({
        type: 'POST',
        data: { "id": id },
        url: '/Admin/ClientUser/Delete',
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