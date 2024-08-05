export function getSliderValue() {
    if ($("#slider-tooltips").length > 0) {
        var tooltipSlider = document.getElementById('slider-tooltips');
        return tooltipSlider.noUiSlider.get();
    }
}