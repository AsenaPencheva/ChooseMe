(function () {
    $('#color-drop').change(function () {
        if ($("#color-drop option:selected").text() === '-- Select a pattern--') {
            window.location.href = '/Animals/All';
        } else {
            window.location.href = '/Animals/All?furColorFilter=' + $("#color-drop option:selected").text();
        }
    });
    $('#specie-drop').change(function () {
        if ($("#specie-drop option:selected").text() === '-- Dog or Cat --') {
            window.location.href = '/Animals/All';
        } else {
            window.location.href = '/Animals/All?type=' + $("#specie-drop option:selected").text();
        }
    });
}());