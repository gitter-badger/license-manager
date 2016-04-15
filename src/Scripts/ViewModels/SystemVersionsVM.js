var SystemVersionsVM = function (json) {
    var self = this;

    self.Table = ko.observableArray([]);
    ko.mapping.fromJS(json, {}, self.Table);

    self.DeleteLock = false;
    self.DeleteActionUrl = '';

    self.Delete = function (systemVersion) {
        if (!systemVersion.Deleted()) {
            if (!self.DeleteLock) {
                self.DeleteLock = true;
                $.ajax({
                    url: self.DeleteActionUrl + '/' + systemVersion.Id(),
                    type: 'DELETE',
                    complete: function (xhr) {
                        if (xhr.status == 200) {
                            systemVersion.Deleted(true);
                        } else {
                            // TODO
                        }
                        self.DeleteLock = false;
                    }
                });
            }
        }
    }
};