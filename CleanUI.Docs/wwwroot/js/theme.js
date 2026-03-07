let SWITCH_THEME_BTN = undefined;

function switchTheme() {
	const current = document.documentElement.dataset['theme'];
	const next = (current === undefined) || (current !== 'light') ? 'light' : 'dark';

	document.documentElement.dataset['theme'] = next;
	document.cookie = `CleanUI.Theme=${next}; samesite=Lax; max-age=31536000`;

	SWITCH_THEME_BTN ??= document.getElementById('switch-theme-btn');
	SWITCH_THEME_BTN.innerHTML = `
	<svg viewBox="0 0 24 24" class="icon" aria-hidden="true"><use href="/_content/CleanUI/icons.svg#${(next === 'dark' ? 'moon' : 'sun')}"></use></svg>
	`;
}
