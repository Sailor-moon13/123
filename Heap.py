class Heap:
    def __init__(self):
        self.heap = []

    def parent(self, index):
        return (index - 1) // 2

    def left_child(self, index):
        return 2 * index + 1

    def right_child(self, index):
        return 2 * index + 2

    def has_left_child(self, index):
        return self.left_child(index) < len(self.heap)

    def has_right_child(self, index):
        return self.right_child(index) < len(self.heap)

    def heapify_up(self, index):
        while index > 0 and self.heap[index] < self.heap[self.parent(index)]:
            # Swap current index with its parent
            self.heap[index], self.heap[self.parent(index)] = self.heap[self.parent(index)], self.heap[index]
            index = self.parent(index)

    def heapify_down(self, index):
        smallest = index
        if self.has_left_child(index) and self.heap[self.left_child(index)] < self.heap[smallest]:
            smallest = self.left_child(index)
        if self.has_right_child(index) and self.heap[self.right_child(index)] < self.heap[smallest]:
            smallest = self.right_child(index)
        if smallest != index:
            # Swap current index with the smallest child
            self.heap[index], self.heap[smallest] = self.heap[smallest], self.heap[index]
            self.heapify_down(smallest)

    def add(self, value):
        self.heap.append(value)
        self.heapify_up(len(self.heap) - 1)

    def remove_min(self):
        if not self.heap:
            raise IndexError("Удаление из пустой кучи.")
        if len(self.heap) == 1:
            return self.heap.pop()
        min_value = self.heap[0]
        self.heap[0] = self.heap.pop()  # замена корня на последний элемент
        self.heapify_down(0)
        return min_value

    def decrease_key(self, index, new_value):
        if index < 0 or index >= len(self.heap):
            raise IndexError("Индекс вне диапазона.")
        if new_value > self.heap[index]:
            raise ValueError("Новое значение больше текущего.")
        self.heap[index] = new_value
        self.heapify_up(index)

    def increase_key(self, index, new_value):
        if index < 0 or index >= len(self.heap):
            raise IndexError("Индекс вне диапазона.")
        if new_value < self.heap[index]:
            raise ValueError("Новое значение меньше текущего.")
        self.heap[index] = new_value
        self.heapify_down(index)

    def get_min(self):
        if not self.heap:
            raise IndexError("Куча пуста.")
        return self.heap[0]

    def is_empty(self):
        return len(self.heap) == 0

    def size(self):
        return len(self.heap)
