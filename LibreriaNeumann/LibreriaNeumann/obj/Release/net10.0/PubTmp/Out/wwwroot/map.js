window.initMap = (idMap,latitud,longitud) => {
    const map = L.map(idMap).setView([-34.921819, -57.963100], 15);

    document.body.style.overflowY = "auto";
    document.documentElement.style.overflowY = "auto";

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '© OpenStreetMap contributors'
    }).addTo(map);

    L.marker([latitud, longitud])
        .addTo(map)
        .bindPopup(`
            <div style="text-align:center">
                <strong>Librería Neumann</strong><br/>
                <a href="https://maps.app.goo.gl/LSqEe9tFh72kEoNy8"
                target = "_blank"
                style= "color:#0d6efd; text-decoration:none; font-weight:600;">
                Ver cómo llegar
                </a>
            </div>
        `)
        .openPopup();
};
