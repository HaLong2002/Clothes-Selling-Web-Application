let detailPopUp = document.getElementById("detailPopUp");
let detailBtn = document.getElementsByClassName('detail');

function add(overlay, popup) {
    overlay.style.display = 'block';
    popup.style.display = 'block';
}

for (let i = 0; i < cancelPopup.length; i++) {
    cancelPopup[i].addEventListener('click', function () {
        overlay.style.display = 'none';
        detailPopUp.style.display = 'none';
    });
}

for (let i = 0; i < detailBtn.length; i++) {
    detailBtn[i].addEventListener('click', function () {
        add(overlay, detailPopUp);
    });
}
