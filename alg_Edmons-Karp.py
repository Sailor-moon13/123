from collections import deque

class EdmondsKarp:
    def __init__(self, n):
        self.n = n  # Количество вершин
        self.capacity = [[0] * n for _ in range(n)]  # Матрица пропускных способностей
        self.flow = [[0] * n for _ in range(n)]  # Матрица потоков

    def add_edge(self, u, v, cap):
        self.capacity[u][v] += cap  # Добавление ребра с пропускной способностью

    def bfs(self, source, sink, parent):
        visited = [False] * self.n
        queue = deque([source])
        visited[source] = True

        while queue:
            u = queue.popleft()

            for v in range(self.n):
                # Если вершина еще не посещена и доступная пропускная способность больше 0
                if not visited[v] and self.capacity[u][v] - self.flow[u][v] > 0:
                    queue.append(v)
                    visited[v] = True
                    parent[v] = u
                    if v == sink:
                        return True
        return False

    def edmonds_karp(self, source, sink):
        parent = [-1] * self.n  # Массив для хранения пути
        max_flow = 0  # Начальный поток

        # Увеличиваем поток, пока существует путь от source к sink
        while self.bfs(source, sink, parent):
            path_flow = float('Inf')
            s = sink

            # Находим максимальный поток в найденном пути
            while s != source:
                path_flow = min(path_flow, self.capacity[parent[s]][s] - self.flow[parent[s]][s])
                s = parent[s]

            # Обновляем потоки для всех ребер в этом пути
            v = sink
            while v != source:
                u = parent[v]
                self.flow[u][v] += path_flow
                self.flow[v][u] -= path_flow
                v = parent[v]

            max_flow += path_flow

        return max_flow

# Пример использования
if __name__ == "__main__":
    # Создаем граф с 6 вершинами
    ek = EdmondsKarp(6)

    # Добавление ребер (u, v, capacity)
    ek.add_edge(0, 1, 16)
    ek.add_edge(0, 2, 13)
    ek.add_edge(1, 2, 10)
    ek.add_edge(1, 3, 12)
    ek.add_edge(2, 1, 4)
    ek.add_edge(2, 4, 14)
    ek.add_edge(3, 2, 9)
    ek.add_edge(3, 5, 20)
    ek.add_edge(4, 3, 7)
    ek.add_edge(4, 5, 4)

    source = 0
    sink = 5
    
    max_flow = ek.edmonds_karp(source, sink)
    print(f"Максимальный поток: {max_flow}")
