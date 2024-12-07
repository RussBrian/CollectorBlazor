function saveLastVisitedUrl(url) {
    localStorage.setItem('lastVisitedUrl', url);
}

function getLastVisitedUrl() {
    return localStorage.getItem('lastVisitedUrl') || '/';
}

window.addEventListener('beforeunload', () => {
    const currentUrl = window.location.pathname + window.location.search;
    localStorage.setItem('lastVisitedUrl', currentUrl);
});
