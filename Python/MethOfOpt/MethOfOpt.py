import random
import numpy as np
import matplotlib.pyplot as plt

# Methods Of Optimization
class MOO:
    def __init__(self):
        # TO DO
        return

    # Поиск интервала оптимальности алгоритмом Свенна
    def svenn(self, x0, t):
        p = func(x0)
        a = func(x0 - t)
        b = func(x0 + t)

        if a >= p and p <= b:
            L = [x0 - t, x0 + t]
        elif a >= p and p >= b:
            L = self.svenn(b, t)
        elif a <= p and p <= b:
            L = self.svenn(a, -t)
        else:
            L = np.nan

        return L

    # Метод равномерного поиска
    def uniform_search(self, L0, N, min = 1000):
        a, b = L0[0], L0[1]
        
        for i in range(1, N + 1):
            x = a + i * (b - a) / (N + 1)
            if func(x) < min:
                min = x

        return min

    # Метод Дитохомии
    def dichotomy(self, L0, l):
        a, b = L0[0], L0[1]
        L = np.absolute(b - a)

        x = (a + b) / 2
        y = a + L / 4
        z = b - L / 4
        f_x = func(x)
        f_y = func(y)
        f_z = func(z)

        if f_y < f_x:
            b = x
            x = y
        else:
            if f_z < f_x:
                a = x
                x = z
            else:
                a = y
                b = z

        L = np.absolute(b - a)
        if L > l:
            x = self.dichotomy([a, b], l)

        return x

    # Метод золотого сечения
    def golden_section_search(self, L0, l):
        a, b = L0[0], L0[1]
        y = a + (b - a) * (3 - np.sqrt(5)) / 2
        z = a + b - y
        f_y = func(y)
        f_z = func(z)

        if f_y <= f_z:
            b = z
            y = a + b - y
            z = y
        else:
            a = z
            y = z
            z = a + b - z

        L = np.absolute(b - a)
        if L <= l:
            x = (a + b) / 2
        else:
            x = self.golden_section_search([a, b], l)

        return x

    def fibonacci(self, N):
        if N in (1, 2):
            F = 1
        else:
            F = self.fibonacci(N - 1) + self.fibonacci(N - 2)

        return F

    # Метод Фибоначчи
    def fibonacci_search(self, L0, l, e, N = 0, k = 0):
        a, b = L0[0], L0[1]
        L = np.absolute(b - a)
        
        F = 0
        while F < L / l:
            N += 1
            F = self.fibonacci(N)

        y = a + (b - a) * self.fibonacci(N - 2) / self.fibonacci(N)
        z = a + (b - a) * self.fibonacci(N - 1) / self.fibonacci(N)
        f_y = func(y)
        f_z = func(z)

        while k != N - 3:
            f_y = func(y)
            f_z = func(z)

            if f_y <= f_z:
                b = z
                z = y
                y = a + (b - a) * self.fibonacci(N - k - 3) / self.fibonacci(N - k - 1)
            else:
                a = y
                y = z
                z = a + (b - a) * self.fibonacci(N - k - 2) / self.fibonacci(N - k - 1)

            k += 1

        x = (a + b)/2
        
        return x

    # Метод градиентного спуска с постоянным шагом
    def gradient(self, x0, e, N):
        for i in range(0, N):
            diff = (func(x0 + e) - func(x0)) / e
            x0 = x0 - e * diff

        return x0

# Функция вариант 22
def func(x):
    f = 0.75 * np.power(x, 4) - 2 * np.power(x, 3) + 2
    return f

# main функция
if __name__ == '__main__':
    method = MOO()

    interval = method.svenn(x0 = 0, t = 2)

    uni_search = method.uniform_search(L0 = interval, N = 1000)
    dichotomy_search = method.dichotomy(L0 = interval, l = 0.001)
    golden_search = method.golden_section_search(L0 = interval, l = 0.001)
    fibonacci_search = method.fibonacci_search(L0 = interval, l = 0.01, e = 0.01)

    x0 = random.randint(interval[0], interval[1])
    gradient_search = method.gradient(x0 = x0, e = 0.001, N = 1000)

    # Вывод результатов
    print('Interval:', interval,
          '\nUniform search:', uni_search,
          '\nDichotomy search:', dichotomy_search,
          '\nGolden section search:', golden_search,
          '\nFibonacci search:', fibonacci_search,
          '\nGradient search:', gradient_search)
    
    # Вывод графика
    x = np.linspace(interval[0], interval[1], 1000)
    plt.xlabel("X")
    plt.ylabel("Y")
    plt.plot(x, func(x))
    plt.grid()
    plt.show()
