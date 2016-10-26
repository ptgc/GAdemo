gaProductPageView = function (gaItem) {
    // Measures product impressions and also tracks a standard
    // pageview for the tag configuration.
    // Product impressions are sent by pushing an impressions object
    // containing one or more impressionFieldObjects.

    var products = getJsonFromGaProducts(gaItem.Products);
    dataLayer.push({
        'ecommerce': {
            'currencyCode': gaItem.CurrencyCode,                       // Local currency is optional.
            'detail': {
                //'actionField': {'list': 'Apparel Gallery'},    // 'detail' actions have an optional list property.
                'products': products
            }
        }
    });
};

gaAddToCart = function (gaItem) {
    // Measure adding a product to a shopping cart by using an 'add' actionFieldObject
    // and a list of productFieldObjects.

    var products = getJsonFromGaProducts(gaItem.Products);
    dataLayer.push({
        'event': "addToCart",
        'ecommerce': {
            'currencyCode': gaItem.CurrencyCode,
            'add': {
                // 'add' actionFieldObject measures.
                'products': products
            }
        }
    });
};

gaRemoveFromCart = function (gaItem) {
    // Measure the removal of a product from a shopping cart.

    var products = getJsonFromGaProducts(gaItem.Products);
    window.dataLayer.push({
        'event': "removeFromCart",
        'ecommerce': {
            'remove': {
                // 'remove' actionFieldObject measures.
                'products': products
            }
        }
    });
};

gaCheckout = function (gaItem, step) {
    /**
 * A function to handle a click on a checkout button. This function uses the eventCallback
 * data layer variable to handle navigation after the ecommerce data has been sent to Google Analytics.
 */
    var products = getJsonFromGaProducts(gaItem.Products);

    dataLayer.push({
        'event': 'checkout',
        'ecommerce': {
            'checkout': {
                'actionField': {
                    'step': step,
                    //'option': 'Visa'
                },
                'products': products
            }
        },
        //'eventCallback': function () {
        //    document.location = 'checkout.html';
        //}
    });
};

gaOrderconfirmation = function (gaItem) {
    // Send transaction data with a pageview if available
    // when the page loads. Otherwise, use an event when the transaction
    // data becomes available.
    var products = getJsonFromGaProducts(gaItem.Products);

    dataLayer.push({
        'ecommerce': {
            'currencyCode': gaItem.CurrencyCode,
            'purchase': {
                'actionField': {
                    'id': gaItem.TransactionId, // Transaction ID. Required for purchases and refunds.
                    'affiliation': '',
                    'revenue': gaItem.TotalPrice, // Total transaction value (incl. tax and shipping)
                    'tax': gaItem.TotalTax,
                    'shipping': gaItem.TotalShipping,
                    'coupon': gaItem.Cupon
                },
                'products': products
            }
        }
    });
};


function getJsonFromGaProducts(gaProducts) {
    var productString = '{"products":[]}';
    var productsList = JSON.parse(productString);
    gaProducts.forEach(function (item, index) {
        var product = {
            "name": item.NameWithId,
            "id": item.SkuId,
            "price": item.Price,
            "brand": item.Brand,
            "category": item.Category,
            "variant": item.Variant,
            "quantity": item.Quantity
        };
        productsList.products.push(product);
    });

    //products += "{" +
    //    "'name': '" + item.NameWithId + "'" +
    //    "'id': '" + item.SkuId + "'," +
    //    "'price': '" + item.Price + "'," +
    //    "'brand': '" + item.Brand + "'," +
    //    "'category': '" + item.Category + "'," +
    //    "'variant': '" + item.Variant + "'," +
    //    "'quantity': " + item.Quantity + "" +
    //    "},";

    return productsList.products;
}