<template>
  <div class="container mx-auto">
    <h1 class="text-center font-bold text-2xl pb-5 pt-2">Produtos</h1>

    <div v-if="load">
      <Pulse class="mb-2" />
      <Pulse class="mb-2" />
      <Pulse class="mb-2" />
    </div>
    
    <div v-else class="flex flex-wrap justify-center">
      <div v-for="item in products.value" :key="item.id" class="m-1">  
        <div class="border border-gray-400 lg:border-gray-400 bg-white rounded-b lg:rounded-b-none lg:rounded-r flex flex-col leading-normal">
          <div class="pb-5 m-4">
            <div class="text-gray-900 font-bold text-xl mb-2">{{ item.name }}  <span class="text-sm bg-green-600 rounded-lg px-2 py-1 text-white font-b">R$ {{ item.price.toLocaleString('pt-br', {minimumFractionDigits: 2}) }}</span></div>
            <p class="text-gray-700 text-base">{{ item.description }}</p>
            <p>{{ item.quantity }} unidades</p>
          </div>
            <span class="bg-yellow-200 px-2 py-1 text-xs absolute right-1 bottom-1">{{item.kind === 0 ? "Orgânico" : "Não orgânico"}}</span>
        </div>
      </div>
    </div>

    <div class="w-fit mx-auto">
      <div v-if="load">
        <span class="flex h-3 w-3">
          <span class="animate-ping absolute inline-flex h-full w-full rounded-full bg-sky-400 opacity-75"></span>
          <span class="relative inline-flex rounded-full h-3 w-3 bg-sky-500"></span>
        </span>
      </div>
      <div v-else class="inline-block" v-for="n in allPages" :key="n">
        <button @click="paginacao(n)" :class="[currentPage == n ? 'bg-blue-700 text-white' : '']" class="bg-blue-400  p-2 mx-2 rounded-full hover:bg-slate-400"  >
          {{n}}
        </button>
      </div>
    </div>


  </div>
</template>


<script lang="ts" setup>
  import Product from '../services/product'
  import { onMounted, reactive, ref } from 'vue'
import Pulse from '../components/Pulse.vue'

  const products = reactive({})
  const load = ref(true)

  //paginação
  const page = ref(1)
  const allPages = ref(0)
  const currentPage = ref(1)

  function paginacao(num){
    load.value = true
    Product.listProducts(num).then((resp) => {
      products.value = resp.data.products;
      allPages.value = resp.data.pages;
      currentPage.value = resp.data.correntPage;

      console.log(allPages.value)
      load.value = false
    })
  }

  onMounted(() => {
    paginacao(page.value)
  })
  
</script>
