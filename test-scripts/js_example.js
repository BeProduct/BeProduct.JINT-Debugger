function fibonacci(n) {
    if (n <= 1) return n;
    return fibonacci(n - 1) + fibonacci(n - 2);
}

for (var i = 0; i < 10; i++) {
    log('Fibonacci(' + i + ') = ' + fibonacci(i));
}
