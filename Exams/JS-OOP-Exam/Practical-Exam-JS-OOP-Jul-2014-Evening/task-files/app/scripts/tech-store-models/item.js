define(function() {
    var Item;

    Item = (function() {
        var validItemTypes = [
            'accessory',
            'smart-phone',
            'notebook',
            'pc',
            'tablet'
        ];

        function isValidType(type) {
            var isValidType = false;

            for (var i = 0; i < validItemTypes.length; i++) {
                if (type === validItemTypes[i]) {
                    isValidType = true;
                    break;
                }
            }

            return isValidType;
        }

        function Item(type, name, price) {
            if (isValidType(type)) {
                this.type = type;
            }
            else {
                throw new Error('Item type is not valid!');
            }

            if (name.length < 6 || name.length > 40) {
                throw new RangeError('Item\'s name length must be between 6 and 40 symbols!');
            }
            else {
                this.name = name;
            }

            this.price = price;
        }

        return Item;
    }());

    return Item;
});