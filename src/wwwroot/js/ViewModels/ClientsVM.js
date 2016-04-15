var ClientsVM = function (json) {
    var self = this;

    self.Table = ko.observableArray([]);
    ko.mapping.fromJS(json, {}, self.Table);

    self.DeleteLock = false;
    self.DeleteActionUrl = '';

    self.Delete = function (client) {
        if (!client.Deleted()) {
            if (!self.DeleteLock) {
                self.DeleteLock = true;
                $.ajax({
                    url: self.DeleteActionUrl + '/' + client.Id(),
                    type: 'DELETE',
                    complete: function (xhr) {
                        if (xhr.status == 200) {
                            client.Deleted(true);
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