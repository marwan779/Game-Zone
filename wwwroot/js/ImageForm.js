// Image preview function
document.querySelector('input[type = "file"]').addEventListener("change", function (event) {
	var input = event.target;

	if (input.files && input.files[0]) {
		var File = new FileReader();

		File.onload = function (e) {
			var image = document.querySelector(".cover-preview");
			image.setAttribute("src", e.target.result);
			image.classList.remove("d-none")
		};

		File.readAsDataURL(input.files[0]);
	}
});