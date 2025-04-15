<template>
  <div class="container">
    <h1 class="main-title">Управление</h1>

    <!-- Клиенты -->
    <section class="section">
      <h2 class="section-title">Клиенты</h2>
      <div class="list-container">
        <ul class="list">
          <li v-for="client in clients" :key="client.id" class="list-item">
            <div class="item-details">
              <p><strong>ID:</strong> {{ client.id }}</p>
              <p><strong>Код:</strong> {{ client.code }}</p>
              <p><strong>Имя:</strong> {{ client.name }}</p>
              <p><strong>Контакты:</strong> {{ client.contactInfo }}</p>
            </div>
            <div class="item-actions">
              <button @click="deleteClient(client.id)" class="delete-btn">Удалить</button>
            </div>
          </li>
        </ul>
      </div>
    </section>

    <!-- Сотрудники -->
    <section class="section">
      <h2 class="section-title">Сотрудники</h2>
      <div class="list-container">
        <ul class="list">
          <li v-for="employee in employees" :key="employee.id" class="list-item">
            <div class="item-details">
              <p><strong>ID:</strong> {{ employee.id }}</p>
              <p><strong>Полное имя:</strong> {{ employee.fullName }}</p>
              <p><strong>Должность:</strong> {{ employee.position }}</p>
            </div>
            <div class="item-actions">
              <button @click="deleteEmployee(employee.id)" class="delete-btn">Удалить</button>
            </div>
          </li>
        </ul>
      </div>
    </section>

    <!-- Инвентаризации -->
    <section class="section">
      <h2 class="section-title">Инвентаризации</h2>
      <div class="list-container">
        <ul class="list">
          <li v-for="inventory in inventories" :key="inventory.id" class="list-item">
            <div class="item-details">
              <p><strong>ID:</strong> {{ inventory.id }}</p>
              <p><strong>Склад:</strong> {{ inventory.warehouseId }}</p>
              <p><strong>Дата:</strong> {{ inventory.date }}</p>
              <p><strong>Статус:</strong> {{ inventory.status }}</p>
            </div>
            <div class="item-actions">
              <button @click="deleteInventory(inventory.id)" class="delete-btn">Удалить</button>
            </div>
          </li>
        </ul>
      </div>
    </section>

    <!-- Продукты -->
    <section class="section">
      <h2 class="section-title">Продукты</h2>
      <div class="list-container">
        <ul class="list">
          <li v-for="product in products" :key="product.id" class="list-item">
            <div class="item-details">
              <p><strong>ID:</strong> {{ product.id }}</p>
              <p><strong>Код:</strong> {{ product.code }}</p>
              <p><strong>Название:</strong> {{ product.name }}</p>
              <p><strong>Бренд:</strong> {{ product.brand }}</p>
              <p><strong>Группа:</strong> {{ product.group }}</p>
            </div>
            <div class="item-actions">
              <button @click="deleteProduct(product.id)" class="delete-btn">Удалить</button>
            </div>
          </li>
        </ul>
      </div>
    </section>

    <!-- Продажи -->
    <section class="section">
      <h2 class="section-title">Продажи</h2>
      <div class="list-container">
        <ul class="list">
          <li v-for="sale in sales" :key="sale.id" class="list-item">
            <div class="item-details">
              <p><strong>ID:</strong> {{ sale.id }}</p>
              <p><strong>Магазин:</strong> {{ sale.storeId }}</p>
              <p><strong>Клиент:</strong> {{ sale.clientId }}</p>
              <p><strong>Сотрудник:</strong> {{ sale.employeeId }}</p>
              <p><strong>Дата:</strong> {{ sale.date }}</p>
              <p><strong>Сумма:</strong> {{ sale.totalAmount }}</p>
              <p><strong>Скидка %:</strong> {{ sale.discountPercent }}</p>
            </div>
            <div class="item-actions">
              <button @click="deleteSale(sale.id)" class="delete-btn">Удалить</button>
            </div>
          </li>
        </ul>
      </div>
    </section>

    <!-- Покупки -->
    <section class="section">
      <h2 class="section-title">Покупки</h2>
      <div class="list-container">
        <ul class="list">
          <li v-for="purchase in purchases" :key="purchase.id" class="list-item">
            <div class="item-details">
              <p><strong>ID:</strong> {{ purchase.id }}</p>
              <p><strong>Склад:</strong> {{ purchase.warehouseId }}</p>
              <p><strong>Дата:</strong> {{ purchase.date }}</p>
              <p><strong>Сумма:</strong> {{ purchase.totalAmount }}</p>
              <p><strong>Поставщик:</strong> {{ purchase.supplier }}</p>
            </div>
            <div class="item-actions">
              <button @click="deletePurchase(purchase.id)" class="delete-btn">Удалить</button>
            </div>
          </li>
        </ul>
      </div>
    </section>

    <!-- Поставщики -->
    <section class="section">
      <h2 class="section-title">Поставщики</h2>
      <div class="list-container">
        <ul class="list">
          <li v-for="supplier in suppliers" :key="supplier.id" class="list-item">
            <div class="item-details">
              <p><strong>ID:</strong> {{ supplier.id }}</p>
              <p><strong>Код:</strong> {{ supplier.code }}</p>
              <p><strong>Название:</strong> {{ supplier.name }}</p>
              <p><strong>Контакты:</strong> {{ supplier.contactInfo }}</p>
            </div>
            <div class="item-actions">
              <button @click="deleteSupplier(supplier.id)" class="delete-btn">Удалить</button>
            </div>
          </li>
        </ul>
      </div>
    </section>

    <!-- Склады -->
    <section class="section">
      <h2 class="section-title">Склады</h2>
      <div class="list-container">
        <ul class="list">
          <li v-for="warehouse in warehouses" :key="warehouse.id" class="list-item">
            <div class="item-details">
              <p><strong>ID:</strong> {{ warehouse.id }}</p>
              <p><strong>Код:</strong> {{ warehouse.code }}</p>
              <p><strong>Название:</strong> {{ warehouse.name }}</p>
              <p><strong>Адрес:</strong> {{ warehouse.address }}</p>
            </div>
            <div class="item-actions">
              <button @click="deleteWarehouse(warehouse.id)" class="delete-btn">Удалить</button>
            </div>
          </li>
        </ul>
      </div>
    </section>

    <!-- Заказы -->
    <section class="section">
      <h2 class="section-title">Заказы</h2>
      <div class="list-container">
        <ul class="list">
          <li v-for="order in orders" :key="order.id" class="list-item">
            <div class="item-details">
              <p><strong>ID:</strong> {{ order.id }}</p>
              <p><strong>Клиент:</strong> {{ order.clientName }}</p>
              <p><strong>Адрес:</strong> {{ order.address }}</p>
              <p><strong>Комментарий:</strong> {{ order.comment }}</p>
              <p><strong>Статус:</strong> {{ order.status }}</p>
              <p><strong>Дата доставки:</strong> {{ new Date(order.deliveryDate).toLocaleString() }}</p>
            </div>
          </li>
        </ul>
      </div>
    </section>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import axios from 'axios'

// Укажите здесь базовый URL для вашего API
const BASE_URL = 'http://localhost:5000';

// Получение данных о клиентах
const clients = ref([]);
const fetchClients = async () => {
  clients.value = (await axios.get(`${BASE_URL}/api/client`)).data;
};
const deleteClient = async (id) => {
  await axios.delete(`${BASE_URL}/api/client/${id}`);
  await fetchClients();
};

// Получение данных о сотрудниках
const employees = ref([]);
const fetchEmployees = async () => {
  employees.value = (await axios.get(`${BASE_URL}/api/employee`)).data;
};
const deleteEmployee = async (id) => {
  await axios.delete(`${BASE_URL}/api/employee/${id}`);
  await fetchEmployees();
};

// Получение данных о инвентаризациях
const inventories = ref([]);
const fetchInventories = async () => {
  inventories.value = (await axios.get(`${BASE_URL}/api/inventory`)).data;
};
const deleteInventory = async (id) => {
  await axios.delete(`${BASE_URL}/api/inventory/${id}`);
  await fetchInventories();
};

// Получение данных о движениях
const movements = ref([]);
const fetchMovements = async () => {
  movements.value = (await axios.get(`${BASE_URL}/api/movement`)).data;
};
const deleteMovement = async (id) => {
  await axios.delete(`${BASE_URL}/api/movement/${id}`);
  await fetchMovements();
};

// Получение данных о продуктах
const products = ref([]);
const fetchProducts = async () => {
  products.value = (await axios.get(`${BASE_URL}/api/product`)).data;
};
const deleteProduct = async (id) => {
  await axios.delete(`${BASE_URL}/api/product/${id}`);
  await fetchProducts();
};

// Получение данных о продажах
const sales = ref([]);
const fetchSales = async () => {
  sales.value = (await axios.get(`${BASE_URL}/api/sale`)).data;
};
const deleteSale = async (id) => {
  await axios.delete(`${BASE_URL}/api/sale/${id}`);
  await fetchSales();
};

// Получение данных о покупках
const purchases = ref([]);
const fetchPurchases = async () => {
  purchases.value = (await axios.get(`${BASE_URL}/api/purchase`)).data;
};
const deletePurchase = async (id) => {
  await axios.delete(`${BASE_URL}/api/purchase/${id}`);
  await fetchPurchases();
};

// Получение данных о поставщиках
const suppliers = ref([]);
const fetchSuppliers = async () => {
  suppliers.value = (await axios.get(`${BASE_URL}/api/supplier`)).data;
};
const deleteSupplier = async (id) => {
  await axios.delete(`${BASE_URL}/api/supplier/${id}`);
  await fetchSuppliers();
};

// Получение данных о складах
const warehouses = ref([]);
const fetchWarehouses = async () => {
  warehouses.value = (await axios.get(`${BASE_URL}/api/warehouse`)).data;
};
const deleteWarehouse = async (id) => {
  await axios.delete(`${BASE_URL}/api/warehouse/${id}`);
  await fetchWarehouses();
};

// Получение данных о заказах
const orders = ref([]);
const fetchOrders = async () => {
  orders.value = (await axios.get(`${BASE_URL}/api/order`)).data;
};


onMounted(() => {
  fetchClients()
  fetchEmployees()
  fetchInventories()
  fetchMovements()
  fetchProducts()
  fetchSales()
  fetchPurchases()
  fetchSuppliers()
  fetchWarehouses()
  fetchOrders()
})
</script>

<style scoped>
* {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
}

body {
  font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
  background-color: #ffffff;
  color: #2c3e50;
  margin: 0;
  padding: 0;
}

.container {
  width: 100%;
  padding: 20px;
  display: flex;
  flex-wrap: wrap; /* позволяет секциям переноситься на новую строку */
  gap: 20px; /* отступы между секциями */
}

.main-title {
  font-size: 3rem;
  color: #e74c3c;
  text-align: center;
  margin-bottom: 30px;
  width: 100%;
}

.section {
  flex: 1 1 calc(33.333% - 20px); /* секции занимают по 1/3 ширины минус отступы */
  margin-bottom: 20px; /* отступ снизу */
  padding: 20px;
  background-color: #2c3e50; 
  color: #ffffff; 
  border-radius: 8px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
}

.section-title {
  font-size: 2rem;
  color: #f39c12;
  margin-bottom: 10px;
}

.list-container {
  max-height: 300px;
  overflow-y: auto;
}

.list {
  list-style-type: none;
}

.list-item {
  padding: 10px;
  margin-bottom: 10px;
  background-color: #34495e;
  border-radius: 6px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}

.item-details p {
  margin: 5px 0;
  font-size: 0.9rem;
  color: #ecf0f1;
}

.item-actions button {
  background-color: #e67e22;
  color: white;
  padding: 8px 16px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.item-actions button:hover {
  background-color: #f39c12;
}

@media (max-width: 1024px) {
  .section {
    flex: 1 1 calc(50% - 20px); /* на более узких экранах секции занимают 50% ширины */
  }
}

@media (max-width: 768px) {
  .section {
    flex: 1 1 100%; /* на мобильных экранах секции занимают всю ширину */
  }
}

</style>
