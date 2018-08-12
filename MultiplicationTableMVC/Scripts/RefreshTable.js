function refreshTableView() {
	$.ajax({
		type: "POST",
		url: '/Multiply/RefreshDisplayTable',
		data: {
			size: $('#Size').val(),
			representation: $('#Representation').val()
		},
		success: function (data) {
			$("body").html(data);
		}
	});
}


function validateChange() {
	var size = $('#Size').val();
	var representation = $('#Representation :selected').text().toLowerCase();

	var updated = false;

	if ($('#hdSize').val() == size && $('#hdRepresenation').val().toLowerCase() == representation)
		updated = false;
	else
		updated = true;

	if (updated) {
		$('#btnRefreshTable').removeClass('disabled');
	}
	else {
		$('#btnRefreshTable').addClass('disabled');
	}

}