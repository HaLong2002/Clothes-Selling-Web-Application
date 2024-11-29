//Ajax thêm tài khoản
function themTaiKhoanAdmin() {
    let data = {};
    let formData = $('#add-form').serializeArray();

    // Collect roles
    data['Roles'] = [];
    $.each(formData, function (index, value) {
        if (value.name === 'Roles') {
            data['Roles'].push(value.value);
        } else {
            data[value.name] = value.value;
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

    console.log("Data da nhap khi them:", data);

    // Remove the commented-out roles validation if you want to require at least one role
    if (data['Roles'].length === 0) {
        $("#add-message").html("Vui lòng chọn ít nhất một loại tài khoản").addClass("text-danger");
        return false;
    }

    if (data["Password"] != data["ConfirmPassword"]) {
        $("#add-message").html("Mật khẩu không khớp").addClass("text-danger");
        return false;
    }

    // Rest of the code remains the same
    $.ajax({
        url: '/Admin/AdminUser/Create',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(data),
        dataType: 'json',
        success: function (response) {
            if (response.status) {
                $("#add-message").html(response.message).addClass("text-success");
                setTimeout(function () {
                    window.location.replace("/Admin/AdminUser");
                }, 1000);
            } else {
                $("#add-message").html(response.message).addClass("text-danger").removeClass("text-success");
            }
        },
        error: function (jqXHR) {
            console.log("Error response:", jqXHR.responseText);
            $("#add-message").html("Có lỗi xảy ra. Vui lòng thử lại.").addClass("text-danger");
        }
    });
    return false;
}

function loadRoles() {
    $.ajax({
        type: 'POST',
        url: '/Admin/AdminUser/LoadRoles',
        success: function (response) {
            console.log("Response from server:", response);

            if (!response.success) {
                alert(response.message);
                return;
            }

            const allRoles = response.allRoles;            

            const rolesContainer = $("#add-roles");
            rolesContainer.empty(); // Clear previous content

            allRoles.forEach(role => {
                //const isChecked = user.roles.$values.includes(role); // Check if the user has this role
                const checkboxHtml = `
                    <div class="form-check">
                        <input class="form-check-input" type="checkbox" name="Roles" value="${role}" id="${role}-role">
                        <label class="form-check-label" for="${role}-role">${role}</label>
                    </div>
                `;
                rolesContainer.append(checkboxHtml);
            });
        },
        error: function (jqXHR) {
            console.log("Error response:", jqXHR.responseText);
            alert("An error occurred while loading data.");
        }
    });
}

//load dữ liệu lên form sửa
function loadData(id) {
    $.ajax({
        type: 'POST',
        data: { "id": id },
        url: '/Admin/AdminUser/Index',
        success: function (response) {
            console.log("Response from server:", response);

            if (!response.success) {
                alert(response.message);
                return;
            }

            const user = response.user;
            const allRoles = response.allRoles;
           
            // Populate the form fields with data from the response
            $("#matk").val(user.id); // Ensure you use the correct path to the user object
            $("#suaEmail").val(user.email);
            $("#fullname").val(user.fullName);

            const rolesContainer = $("#roles");
            rolesContainer.empty(); // Clear previous content

            allRoles.forEach(role => {
                const isChecked = user.roles.includes(role); // Check if the user has this role
                const checkboxHtml = `
                    <div class="form-check">
                        <input class="form-check-input" type="checkbox" value="${role}" id="${role}-role" ${isChecked ? 'checked' : ''}>
                        <label class="form-check-label" for="${role}-role">${role}</label>
                    </div>
                `;
                rolesContainer.append(checkboxHtml);
            });

            $(`#${user.emailConfirmed ? 'confirmed' : 'notconfirmed'}`).prop("checked", true);
            $(`#${user.lockoutStatus === "Khóa" ? 'blocked' : 'active'}`).prop("checked", true);
        },
        error: function (jqXHR) {
            console.log("Error response:", jqXHR.responseText);
            alert("An error occurred while loading data.");
        }
    });
}

//ajax sửa tài khoản quản trị
function suaTaiKhoanQuanTri() {
    let data = {};
    let formData = $('#update-form').serializeArray();

    // Convert formData into key-value pairs
    $.each(formData, function (index, value) {
        data[value.name] = value.value;
    });

    data["EmailConfirmed"] = data["EmailConfirmed"] === "true";

    // Collect roles from checkboxes
    let roles = [];
    $("#roles input:checked").each(function () {
        roles.push($(this).val());
    });
    data["Roles"] = roles;

    console.log("Data to submit: ", data);

    const emailInput = document.getElementById("suaEmail");
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

    $.ajax({
        url: '/Admin/AdminUser/Update',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(data),
        dataType: 'json',
        success: function (response) {
            $("#update-message").html(response.message);

            if (response.status) {
                $("#update-message").addClass("text-success").removeClass("text-danger");
                setTimeout(function () {
                    window.location.replace("/Admin/AdminUser");
                }, 1000);
            } else {
                $("#update-message").addClass("text-danger").removeClass("text-success");
            }
        },
        error: function (response) {
            console.error(response);
            $("#update-message").html("Đã xảy ra lỗi.").addClass("text-danger");
        }
    });

    return false; // Prevent default form submission
}


//load data lên form xóa
function deleteData(id) {
    $("#delete-message").html("");
    $("#delete-adminuser-id").val(id);
}

function xoaTaiKhoan() {
    let id = $("#delete-adminuser-id").val();
    $.ajax({
        type: 'POST',
        data: { "id": id },
        url: '/Admin/AdminUser/Delete',
        success: function (response) {
            if (response.status == true) {
                $(".cancelPopup").click();
                $("#row-" + id).remove();
            } else {
                $("#delete-message").html(response.message);
            }
        },
        error: function (response) {
            console.log(xhr.responseText);
            alert("Error has occurred..");
        }
    });  
}