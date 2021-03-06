var ClientsVM = function (json) {
    var self = this;

    self.Table = ko.observableArray([]);
    ko.mapping.fromJS(json, {}, self.Table);
    
    self.ShowDeletedClients = ko.observable(true);
    
    self.DeleteLock = false;

    self.DeleteActionUrl = '';

    self.Delete = function (client) {
        if (!client.Deleted()) {
            if (!self.DeleteLock) {
                self.DeleteLock = true;
                bootbox.setLocale('pl');
                bootbox.confirm('Czy na pewno chcesz usunąć wybranego klienta?', function (result) {
                    if (result) {
                        $.ajax({
                            url: self.DeleteActionUrl + '/' + client.Id(),
                            type: 'DELETE',
                            complete: function (xhr) {
                                if (xhr.status == 200) {
                                    client.Deleted(true);
                                } else {
                                    bootbox.alert('Usunięcie wybranego klienta nie powiodło się (błąd HTTP ' + xhr.status + ').');
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