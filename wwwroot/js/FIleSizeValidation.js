// File size validation
$.validator.addMethod('filesize', function (value, element, param) {
	return this.optional(element) || element.files.size[0] <= param
});