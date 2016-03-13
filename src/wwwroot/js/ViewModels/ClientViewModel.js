var ClientViewModel = function() {
    var self = this;

    self.Name = ko.observable().extend({ required: true, maxLength: 100 });
    self.Description = ko.observable().extend({ maxLength: 500 });

    self.Create = function() {
        if (self.Errors().length == 0) {
            $.ajax({
                url: "/License/CreateClient",
                type: "POST",
                data: ko.mapping.toJSON(self),
                dataType: "json",
                contentType: "application/json",
                success: function(response) {
                    window.location.href = response;
                }
            });
        } else {
            self.Errors.showAllMessages();
        }
    }

    self.Errors = ko.validation.group(self);
};