let map, marker;

function initializeCustomMap(dotNetRef) {
    const mapElement = document.getElementById("custom-map");
    if (!mapElement) {
        console.error("Map element not found!");
        return;
    }

    // Initialize the map
    map = new google.maps.Map(mapElement, {
        center: { lat: 18.4861, lng: -69.9312 }, // Default to Santo Domingo, DR
        zoom: 12,
    });

    // Add a click event listener to place a marker and report the location
    map.addListener("click", (event) => {
        const latitude = event.latLng.lat();
        const longitude = event.latLng.lng();

        if (marker) {
            marker.setMap(null); // Remove existing marker
        }

        marker = new google.maps.Marker({
            position: event.latLng,
            map: map,
        });

        // Notify Blazor of the selected location
        dotNetRef.invokeMethodAsync("ReportLocation", latitude, longitude);
    });
}
