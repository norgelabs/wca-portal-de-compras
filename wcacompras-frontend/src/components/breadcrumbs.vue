<template>
  <v-breadcrumbs>
    <template v-slot:prepend>
      <v-icon size="large" icon="mdi-arrow-left" color="primary" @click="router.go(-1)"></v-icon>
    </template>
    <div class="text-h4 text-primary">{{ title }}</div>
    <v-spacer></v-spacer>
    <v-btn color="primary" variant="outlined" class="text-capitalize mr-1" v-for="(button, index) in buttons"
      @click="$emit(button.event)" :key="index" :disabled="button.disabled??false">
      <v-icon :icon="button.icon" v-if="button.icon != ''"></v-icon>
      <b>{{ button.text }}</b>
    </v-btn>
    &nbsp;
    <v-btn color="primary" variant="outlined" class="text-capitalize" @click="$emit('customClick')"
      v-show="customButtonShow" :disabled="customButtonDisabled">
      <v-icon :icon="customButtonIcon" v-if="customButtonIcon != ''"></v-icon>
      <b>{{ customButtonText }}</b>
    </v-btn>
    &nbsp;
    <v-btn color="primary" variant="outlined" class="text-capitalize" @click="$emit('novoClick')" v-show="showButton">
      <b>Novo</b>
    </v-btn>
  </v-breadcrumbs>
</template>

<script setup>
import router from "@/router"
defineProps({
  title: String,
  showButton: { type: Boolean, default: true },
  customButtonShow: { type: Boolean, default: false },
  customButtonText: { type: String, default: "customButtonText" },
  customButtonIcon: { type: String, default: "" },
  customButtonDisabled: { type: Boolean, default: false },
  buttons: {
    type: Object,
    default: function () {
      return []
    }
  }
})
</script>

<style scoped>

</style>