# Brown-Robinson iterative method for bimatrix games

import numpy as np

# Исходная матрица
matrix = np.array([[3, 2, -1, -3],
                   [4, 5, -3, 2],
                   [1, 3, 0, 0],
                   [6, 8, 1, 2]])

# Названия стратегий
out1, out2 = ['a', 'b', 'c', 'd'], [u'\u03B1', u'\u03B2', u'\u03B3', u'\u03B4']

# Размерность матрицы/стратегий
n = 4


def main():
    w1, w2 = 0, 0
    win1, win2 = np.array([0, 0, 0, 0]), np.array([0, 0, 0, 0])
    prob = [0 for i in range(n*2)]

    iterations = 100
    for i in range(iterations):
        win1 -= matrix[w1, :]
        win2 += matrix[:, w2]

        print('{0}\t|  {1}  |\t{2}\t|  {3}  |\t{4}'.format(i + 1, out1[w1], win1, out2[w2], win2))

        prob[w1] += 1
        prob[w2 + n] += 1

        w1 = np.where(win2 == max(win2))[0][0]
        w2 = np.where(win1 == max(win1))[0][0]

    v2 = max(win1) / iterations
    v1 = max(win2) / iterations
    prob = [i / iterations for i in prob]

    print('\nМатрица:')
    for row in matrix:
        for col in row:
            print(col, end='\t')
        print()

    print('\nВероятности стратегий:')
    for i in range(len(prob)):
        if i < n:
            print('P({1}) = {0}'.format(prob[i], out1[i]))
        else:
            print('P({1}) = {0}'.format(prob[i], out2[i - n]))
    print('\nЦена игры: {0} {2} v {2} {1}'.format(v2, v1, u'\u2264'))

    return


if __name__ == '__main__':
    main()