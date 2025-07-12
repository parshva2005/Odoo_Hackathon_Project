// StackIt Platform JavaScript

document.addEventListener('DOMContentLoaded', function () {
    // Filter tabs functionality
    const filterTabs = document.querySelectorAll('.stackit-filter-tab');
    filterTabs.forEach(tab => {
        tab.addEventListener('click', function () {
            // Remove active class from all tabs
            filterTabs.forEach(t => t.classList.remove('active'));
            // Add active class to clicked tab
            this.classList.add('active');

            // Add animation to question cards
            const questionCards = document.querySelectorAll('.stackit-question-card');
            questionCards.forEach(card => {
                card.style.opacity = '0';
                card.style.transform = 'translateY(20px)';
                setTimeout(() => {
                    card.style.opacity = '1';
                    card.style.transform = 'translateY(0)';
                }, 100);
            });
        });
    });

    // Like button functionality
    const actionButtons = document.querySelectorAll('.stackit-action-btn');
    actionButtons.forEach(button => {
        button.addEventListener('click', function (e) {
            e.stopPropagation();

            // Toggle like state
            if (this.querySelector('i').classList.contains('fa-thumbs-up')) {
                const icon = this.querySelector('i');
                const countSpan = this.querySelector('span');

                if (icon.style.color === 'rgb(0, 224, 255)') {
                    // Unlike
                    icon.style.color = '#666';
                    const currentCount = parseInt(countSpan.textContent);
                    countSpan.textContent = currentCount - 1;
                } else {
                    // Like
                    icon.style.color = '#00e0ff';
                    const currentCount = parseInt(countSpan.textContent);
                    countSpan.textContent = currentCount + 1;
                }
            }

            // Add click animation
            this.style.transform = 'scale(0.95)';
            setTimeout(() => {
                this.style.transform = 'scale(1)';
            }, 150);
        });
    });

    // Question card click functionality
    const questionCards = document.querySelectorAll('.stackit-question-card');
    questionCards.forEach(card => {
        card.addEventListener('click', function (e) {
            // Don't trigger if clicking on action buttons
            if (e.target.closest('.stackit-action-btn')) {
                return;
            }

            // Add click animation
            this.style.transform = 'scale(0.98)';
            setTimeout(() => {
                this.style.transform = 'scale(1)';
            }, 150);

            // Here you would typically navigate to the question detail page
            console.log('Navigating to question detail...');
        });
    });

    // Search functionality
    const searchInput = document.querySelector('.stackit-search-input');
    if (searchInput) {
        searchInput.addEventListener('input', function () {
            const searchTerm = this.value.toLowerCase();
            const questionCards = document.querySelectorAll('.stackit-question-card');

            questionCards.forEach(card => {
                const title = card.querySelector('.stackit-question-title').textContent.toLowerCase();
                const desc = card.querySelector('.stackit-question-desc').textContent.toLowerCase();
                const tags = Array.from(card.querySelectorAll('.stackit-tag')).map(tag => tag.textContent.toLowerCase());

                const matches = title.includes(searchTerm) ||
                    desc.includes(searchTerm) ||
                    tags.some(tag => tag.includes(searchTerm));

                if (matches || searchTerm === '') {
                    card.style.display = 'block';
                    card.style.opacity = '1';
                } else {
                    card.style.opacity = '0.5';
                    card.style.display = 'none';
                }
            });
        });
    }

    // Trending topics click functionality
    const trendingItems = document.querySelectorAll('.stackit-trending-item');
    trendingItems.forEach(item => {
        item.addEventListener('click', function () {
            const tag = this.querySelector('.stackit-trending-tag').textContent;
            console.log('Filtering by tag:', tag);

            // Add click animation
            this.style.transform = 'scale(0.95)';
            setTimeout(() => {
                this.style.transform = 'scale(1)';
            }, 150);
        });
    });

    // Navigation links functionality
    const navLinks = document.querySelectorAll('.stackit-nav-link');
    navLinks.forEach(link => {
        link.addEventListener('click', function (e) {
            e.preventDefault();

            // Remove active class from all links
            navLinks.forEach(l => l.classList.remove('active'));
            // Add active class to clicked link
            this.classList.add('active');

            console.log('Navigating to:', this.querySelector('span').textContent);
        });
    });

    // Ask Question button functionality
    const askButton = document.querySelector('.stackit-ask-btn');
    if (askButton) {
        askButton.addEventListener('click', function () {
            console.log('Opening ask question modal...');
            // Here you would typically open a modal or navigate to ask question page
        });
    }

    // Notification and user buttons
    const notificationBtn = document.querySelector('.stackit-notification-btn');
    const userBtn = document.querySelector('.stackit-user-btn');

    if (notificationBtn) {
        notificationBtn.addEventListener('click', function () {
            console.log('Opening notifications...');
        });
    }

    if (userBtn) {
        userBtn.addEventListener('click', function () {
            console.log('Opening user menu...');
        });
    }

    // Add hover effects to cards
    questionCards.forEach(card => {
        card.addEventListener('mouseenter', function () {
            this.style.transform = 'translateY(-4px)';
        });

        card.addEventListener('mouseleave', function () {
            this.style.transform = 'translateY(0)';
        });
    });

    // Add smooth scrolling to pagination
    const paginationButtons = document.querySelectorAll('.stackit-page, .stackit-page-btn');
    paginationButtons.forEach(button => {
        button.addEventListener('click', function () {
            // Add click animation
            this.style.transform = 'scale(0.95)';
            setTimeout(() => {
                this.style.transform = 'scale(1)';
            }, 150);

            console.log('Navigating to page...');
        });
    });

    // Add loading animation for content
    function addLoadingAnimation() {
        const feed = document.querySelector('.stackit-feed');
        if (feed) {
            feed.style.opacity = '0';
            setTimeout(() => {
                feed.style.opacity = '1';
            }, 300);
        }
    }

    // Initialize loading animation
    addLoadingAnimation();

    // Add keyboard shortcuts
    document.addEventListener('keydown', function (e) {
        // Ctrl/Cmd + K for search
        if ((e.ctrlKey || e.metaKey) && e.key === 'k') {
            e.preventDefault();
            const searchInput = document.querySelector('.stackit-search-input');
            if (searchInput) {
                searchInput.focus();
            }
        }

        // Escape to clear search
        if (e.key === 'Escape') {
            const searchInput = document.querySelector('.stackit-search-input');
            if (searchInput && searchInput.value) {
                searchInput.value = '';
                searchInput.dispatchEvent(new Event('input'));
            }
        }
    });

    // Add tooltips for better UX
    const tooltipElements = document.querySelectorAll('[data-tooltip]');
    tooltipElements.forEach(element => {
        element.addEventListener('mouseenter', function () {
            const tooltip = document.createElement('div');
            tooltip.className = 'stackit-tooltip';
            tooltip.textContent = this.getAttribute('data-tooltip');
            tooltip.style.cssText = `
                position: absolute;
                background: #2a2a3e;
                color: #ffffff;
                padding: 8px 12px;
                border-radius: 6px;
                font-size: 0.8rem;
                z-index: 1000;
                pointer-events: none;
                border: 1px solid #3a3a4e;
            `;

            document.body.appendChild(tooltip);

            const rect = this.getBoundingClientRect();
            tooltip.style.left = rect.left + (rect.width / 2) - (tooltip.offsetWidth / 2) + 'px';
            tooltip.style.top = rect.top - tooltip.offsetHeight - 8 + 'px';
        });

        element.addEventListener('mouseleave', function () {
            const tooltip = document.querySelector('.stackit-tooltip');
            if (tooltip) {
                tooltip.remove();
            }
        });
    });

    console.log('StackIt platform initialized successfully!');
});
