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
                bootbox.setLocale('pl');
                bootbox.confirm('Czy na pewno chcesz usunąć wybraną wersję systemu?', function (result) {
                    if (result) {
                        $.ajax({
                            url: self.DeleteActionUrl + '/' + systemVersion.Id(),
                            type: 'DELETE',
                            complete: function (xhr) {
                                if (xhr.status == 200) {
                                    systemVersion.Deleted(true);
                                } else {
                                    bootbox.alert('Usunięcie wybranej wersji systemu nie powiodło się (błąd HTTP ' + xhr.status + ').');
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