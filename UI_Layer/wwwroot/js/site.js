//function refreshCurrencyPairs() {
//    $.get(window.location.origin + "/Home/GetCurrencyPairs", function (data) {
//        const tbody = $("#currencyPairsTable tbody");
//        tbody.empty();
//        data.forEach(pair => {
//            const row = `<tr>
//                <td>${pair.baseCurrency}</td>
//                <td>${pair.quoteCurrency}</td>
//                <td>${pair.minValue}</td>
//                <td>${pair.maxValue}</td>
//            </tr>`;
//            tbody.append(row);
//        });
//    });
//}

//setInterval(refreshCurrencyPairs, 2000);

function refreshCurrencyPairs() {
    $.get(window.location.origin + "/Home/GetCurrencyPairs", function (data) {
        const tbody = $("#currencyPairsTable tbody");
        tbody.empty();
        data.forEach(pair => {
            const row = `<tr>
                <td>${pair.baseCurrency}</td>
                <td>${pair.quoteCurrency}</td>
                <td>${pair.minValue}</td>
                <td>${pair.maxValue}</td>
            </tr>`;
            tbody.append(row);
        });
    });
}

setInterval(refreshCurrencyPairs, 2000);
