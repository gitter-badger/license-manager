var ClientViewModel = function () {
    var self = this;

    self.Name = ko.observable();
    self.Description = ko.observable();

    self.create = function () {
        $.ajax({
            url: "/License/CreateClient",
            type: "POST",
            data: ko.mapping.toJSON(self),
            dataType: "json",
            contentType: "application/json",
            success: function (response) {
                window.location.href = response;
            }
        });
    }
};