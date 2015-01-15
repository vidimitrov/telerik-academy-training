define(['tech-store-models/item'], function(Item) {
    var Store;

    Store = (function() {
        function sortLexicographicallyByName(items) {
            var sortedItems = items.sort(function(item1, item2) {
                return item1.name.localeCompare(item2.name);
            });

            return sortedItems;
        }

        function Store(name) {
            this._items = [];

            if (name.length < 6 || name.length > 30) {
                throw new RangeError('Store\'s name length must be between 6 and 30 symbols!');
            }
            else {
                this.name = name;
            }
        }

        Store.prototype = {
            addItem: function(item) {
                if(item.constructor === Item) {
                    this._items.push(item);
                }
                else {
                    throw new TypeError('Wrong type. Only Item objects are allowed in the Store!');
                }

                return this;
            },
            getAll: function() {
                var clonedItems  = this._items.map(function(item) {
                    return item;
                });

                clonedItems = sortLexicographicallyByName(clonedItems);

                return clonedItems;
            },
            getSmartPhones: function() {
                var smartPhoneItems  = this._items.filter(function(item) {
                    return item.type === 'smart-phone';
                });

                smartPhoneItems = sortLexicographicallyByName(smartPhoneItems);

                return smartPhoneItems;
            },
            getMobiles: function() {
                var mobileItems  = this._items.filter(function(item) {
                    return item.type === 'smart-phone' || item.type === 'tablet';
                });

                mobileItems = sortLexicographicallyByName(mobileItems);

                return mobileItems;
            },
            getComputers: function() {
                var computerItems  = this._items.filter(function(item) {
                    return item.type === 'pc' || item.type === 'notebook';
                });

                computerItems = sortLexicographicallyByName(computerItems);

                return computerItems;
            },
            filterItemsByType: function(filterType) {
                var filteredItems = this._items.filter(function(item) {
                    return item.type === filterType;
                });

                filteredItems = sortLexicographicallyByName(filteredItems);

                return filteredItems;
            },
            filterItemsByPrice: function(options) {
                options = options || {};
                options.min = options.min || 0;
                options.max = options.max || Infinity;
                var filteredItems;

                filteredItems = this._items.filter(function(item) {
                    return item.price > options.min && item.price < options.max;
                });

                filteredItems = filteredItems.sort(function(item1, item2) {
                    return item1.price - item2.price;
                });

                return filteredItems;
            },
            countItemsByType: function() {
                var itemTypesTable = {};

                this._items.forEach(function(item) {
                    if (itemTypesTable[item.type]) {
                        itemTypesTable[item.type]++;
                    }
                    else {
                        itemTypesTable[item.type] = 1;
                    }
                });

                return itemTypesTable;
            },
            filterItemsByName: function(partOfName) {
                var filteredItems;

                filteredItems = this._items.filter(function(item) {
                    return item.name.toLowerCase().indexOf(partOfName.toLowerCase()) !== -1;
                });

                filteredItems = sortLexicographicallyByName(filteredItems);

                return filteredItems;
            }
        };

        return Store;
    }());

    return Store;
});