<script setup lang="ts">
import { RouterLink, RouterView } from "vue-router";
import HelloWorld from "@/components/HelloWorld.vue";
import NavBarTop from "./components/NavBarTop.vue";
</script>

<template>
  <header>
    <NavBarTop />
  </header>

    <!--
    <div class="wrapper">
      <HelloWorld msg="You did it!" />
    </div> 
    -->

  <RouterView />
</template>

<style>
@import "@/assets/base.css";

</style>
