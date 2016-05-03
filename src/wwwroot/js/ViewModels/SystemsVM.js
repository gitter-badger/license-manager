var SystemsVM = function (json) {
    var self = this;

    self.Table = ko.observableArray([]);
    ko.mapping.fromJS(json, {}, self.Table);

    self.DeleteLock = false;

    self.DeleteActionUrl = '';

    self.Delete = function (system) {
        if (!system.Deleted()) {
            if (!self.DeleteLock) {
                self.DeleteLock = true;
                bootbox.setLocale('pl');
                bootbox.confirm('Czy na pewno chcesz usunąć wybrany system?', function (result) {
                    if (result) {
                        $.ajax({
                            url: self.DeleteActionUrl + '/' + system.Id(),
                            type: 'DELETE',
                            complete: function (xhr) {
                                if (xhr.status == 200) {
                                    system.Deleted(true);
                                } else {
                                    bootbox.alert('Usunięcie wybranego systemu nie powiodło się (błąd HTTP ' + xhr.status + ').');
                                }
                                self.DeleteLock = false;
                            }
                        });
                    } else {
                        self.DeleteLock = false;
                    }
                });
            }
        }
    }
};