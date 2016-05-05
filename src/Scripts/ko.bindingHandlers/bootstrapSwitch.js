ko.bindingHandlers.bootstrapSwitch = {
    init: function (element, valueAccessor) {
        $(element).bootstrapSwitch();
        $(element).bootstrapSwitch('state', ko.utils.unwrapObservable(valueAccessor()));
        $(element).on('switchChange.bootstrapSwitch', function (event, state) {
            valueAccessor()(state);
        });
    },
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        if ($(element).bootstrapSwitch('state') != value) {
            $(element).bootstrapSwitch('state', value);
        }
    }
};