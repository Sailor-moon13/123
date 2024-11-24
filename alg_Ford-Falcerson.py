from collections import defaultdict

class Graph:
    def __init__(self, vertices):
        self.V = vertices  # Количество вершин в графе
        self.graph = defaultdict(list)  # Граф в виде словаря со списками

    def add_edge(self, u, v, w):
        # Добавить ребро с пропускной способностью w
        self.graph[u].append((v, w))  # Добавить ребро от u к v
        self.graph[v].append((u, 0))  # Добавить обратное ребро с пропускной способностью 0

    def bfs(self, s, t, parent):
        visited = [False] * self.V
        queue = []

        queue.append(s)
        visited[s] = True

        while queue:
            u = queue.pop(0)

            for v, capacity in self.graph[u]:
                if not visited[v] and capacity > 0:  # Если не посещали и есть оставшаяся пропускная способность
                    queue.append(v)
                    visited[v] = True
                    parent[v] = u

                    if v == t:
                        return True

        return False

    def ford_fulkerson(self, source, sink):
        parent = [-1] * self.V  # Массив для хранения пути
        max_flow = 0  # Инициализация максимального потока

        while self.bfs(source, sink, parent):
            # Найти максимальный поток в пути, найденном BFS
            path_flow = float("Inf")
            v = sink

            while v != source:
                u = parent[v]
                for to, capacity in self.graph[u]:
                    if to == v:
                        path_flow = min(path_flow, capacity)
                v = u

            # Обновить остаточные пропускные способности и обратные потоки
            v = sink
            while v != source:
                u = parent[v]
                for index, (to, capacity) in enumerate(self.graph[u]):
                    if to == v:
                        self.graph[u][index] = (to, capacity - path_flow)
                for index, (to, capacity) in enumerate(self.graph[v]):
                    if to == u:
                        self.graph[v][index] = (to, capacity + path_flow)

                v = u

            max_flow += path_flow

        return max_flow

# Пример использования:
if __name__ == "__main__":
    g = Graph(6)  # Создаем граф с 6 вершинами
    g.add_edge(0, 1, 16)
    g.add_edge(0, 2, 13)
    g.add_edge(1, 2, 10)
    g.add_edge(1, 3, 12)
    g.add_edge(2, 1, 4)
    g.add_edge(2, 4, 14)
    g.add_edge(3, 2, 9)
    g.add_edge(3, 5, 20)
    g.add_edge(4, 3, 7)
    g.add_edge(4, 5, 4)

    source = 0  # Начальная вершина
    sink = 5    # Конечная вершина

    print("Максимальный поток:", g.ford_fulkerson(source, sink))
