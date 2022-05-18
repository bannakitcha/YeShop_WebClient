redirectToCheckout = function (sessionId) {
    var stripe = Stripe("pk_test_51KyARlGCMLFl1xZGMKDNnuttjpWKPyubWLrewOXpVSVemMxb39izCOz1XVkTzd61Sjdk70ljFHazxVDlkgN5usEJ00WeKJ8Y5Q");
    stripe.redirectToCheckout({ sessionId: sessionId });
}