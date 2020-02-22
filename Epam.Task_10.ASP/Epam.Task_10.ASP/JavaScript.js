$('#btn_signout').click(function () {
    location.href = '/Pages/SignOut';
});
$('#removeAward').click(function () {
    var res = confirm("Удалить данную награду? Награда так же удалится у всех пользователей!");
    if (!res) {
        $('#fieldRemoveId').val("");
    }
});