window.initializeLeafletMap = (latitude, longitude, zoom, dotNetRef) => {
    // Inicializar el mapa
    const map = L.map('map').setView([latitude, longitude], zoom);

    // Agregar capa de tiles
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

    // Agregar un marcador inicial
    let marker = L.marker([latitude, longitude], { draggable: true }).addTo(map);

    // Evento al hacer clic en el mapa
    map.on('click', function (e) {
        const { lat, lng } = e.latlng;

        // Mueve el marcador al nuevo lugar
        marker.setLatLng([lat, lng]);

        // Envía las coordenadas seleccionadas al componente Blazor
        if (dotNetRef) {
            dotNetRef.invokeMethodAsync("OnMapClick", lat, lng);
        }
    });
};