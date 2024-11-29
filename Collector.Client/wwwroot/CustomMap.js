let map, marker;

function initializeCustomMap(dotNetRef) {
    const mapElement = document.getElementById("custom-map");
    if (!mapElement) {
        console.error("Map element not found!");
        return;
    }

    map = new google.maps.Map(mapElement, {
        center: { lat:18.4506168, lng: -69.6633953 },
        zoom: 13,
    });

    map.addListener("click", (event) => {
        const latitude = event.latLng.lat();
        const longitude = event.latLng.lng();

        if (marker) {
            marker.setMap(null); 
        }

        marker = new google.maps.Marker({
            position: event.latLng,
            map: map,
        });

        dotNetRef.invokeMethodAsync("ReportLocation", latitude, longitude);
    });
}
