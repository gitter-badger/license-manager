var CreateSystemVersionFormViewModel = function() {
    var self = this;

    self.Major = ko.observable().extend({ required: true, min: 0 });
    self.Minor = ko.observable().extend({ required: true, min: 0 });
    self.Description = ko.observable().extend({ maxLength: 500 });
    self.SystemId = ko.observable().extend({ required: true });
    
    self.SystemDropDownListItems = ko.observableArray();

    self.Save = function() {
        if (self.Errors().length == 0) {
            $.ajax({
                url: "/License/CreateSystemVersion",
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

    self.Clear = function() {
        self.Major("");
        self.Minor("");
        self.Description("");
        self.SystemId("");
    }

    self.Errors = ko.validation.group(self);
};