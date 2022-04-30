<script setup lang="ts">
    import SupportIcon from "./icons/IconSupport.vue";
</script>

<template>
    <nav class="flex items-center flex-wrap bg-black p-6">
        <div class="flex items-center flex-shrink-0 text-white mr-6">
            
            <SupportIcon class="mx-2 text-red-500" />
            <span class="font-semibold text-xl tracking-tight">Descontrolada®</span>
        </div>

        <div class="text-sm">
            <RouterLink to="/">
                <a href="#responsive-header" class=" text-white hover:text-red-500 mr-4">
                    Início
                </a>
            </RouterLink>
            <RouterLink to="/products">
                <a href="#responsive-header" class="text-white hover:text-red-500 mr-4">
                    Produtos
                </a>
            </RouterLink>
        </div>
    </nav>
</template>