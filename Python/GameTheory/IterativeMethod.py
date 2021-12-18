import numpy as np
import csv

# Исходная матрица
matrix = np.array([[3, 2, -1, -3],
                   [4, 5, -3, 2],
                   [1, 3, 0, 0],
                   [6, 8, 1, 2]])

# Названия стратегий
out1, out2 = ['a', 'b', 'c', 'd'], [u'\u03B1', u'\u03B2', u'\u03B3', u'\u03B4']

# Размерность матрицы/стратегий
n = 4

# Название файла с таблицей
table = 'table.csv'


def WriteCSV(name=table, inp_list=[]):
    with open(name, mode='a', newline='') as file:
        writer = csv.writer(file, delimiter=';', quotechar='"', quoting=csv.QUOTE_MINIMAL)
        writer.writerow(inp_list)
    return

# Определение седловой точки (оптимальных стратегий) методом минимакса/максимина
def MinMax():
    minimax, maximin = [], []

    for i in range(n):
        minimax.append(min(matrix[i, :]))
        maximin.append(max(matrix[:, i]))

    i_strat = minimax.index(max(minimax))
    j_strat = maximin.index(min(maximin))
    minimax = max(minimax)
    maximin = min(maximin)

    print('\nВыигрышная стратегия I игрока - {0}\n'
          'Выигрышная стратегия II игрока - {1}\n'.format(i_strat, j_strat))

    if (minimax == maximin):
        print('Игра имеет оптимальную стратегию с ценой игры: v = {0}\n'.format(minimax))

    return (minimax, maximin)


# Определение нижней и верхней цен игры методом итерационного решения Брауна-Робинсона
def IterMeth(iterations=20):
    w1, w2 = 0, 0
    win1, win2 = np.array([0, 0, 0, 0]), np.array([0, 0, 0, 0])
    prob = [0 for i in range(n * 2)]

    for i in range(iterations):
        win1 -= matrix[w1, :]
        win2 += matrix[:, w2]

        print('{0}\t|  {1}  |\t{2}\t|  {3}  |\t{4}'.format(i + 1, out1[w1], win1, out2[w2], win2))
        WriteCSV(inp_list=[i + 1, out1[w1]] + win1.tolist() + [out1[w2]] + win2.tolist())

        prob[w1] += 1
        prob[w2 + n] += 1

        w1 = np.where(win2 == max(win2))[0][0]
        w2 = np.where(win1 == max(win1))[0][0]

    v2 = abs(max(win1) / iterations)
    v1 = abs(max(win2) / iterations)
    prob = [i / iterations for i in prob]

    print('\nВероятности стратегий:')
    print('P =', prob[:n])
    print('Q =', prob[n:])
    print('\nЦена игры: {0} {2} v {2} {1}'.format(v2, v1, u'\u2264'))

    return (v2, v1)


def main():
    # Вывод платежной матрицы игры
    print('\nМатрица:')
    for row in matrix:
        for col in row:
            print(col, end='\t')
        print()

    MinMax()

    open(table, 'w').close()
    IterMeth(iterations=100)

    return


if __name__ == '__main__':
    main()